using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("wave configuration")]
    [Tooltip("reference to all enemy spawn points")]
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [Tooltip("time between enemy spawns base line")]
    [SerializeField] float timeBetweenWaves = 0.5f;
    [Tooltip("bool that defines if game is running")]
    [SerializeField] bool gameRunning = true;
    [Header("wave Progression")]
    [Tooltip("time before timer is triggered")]
    [SerializeField] float timeRemaining = 60f;
    [Tooltip("time that is taken off the time before net enemy spawn")]
    [SerializeField] float timeAmountToTake = 0.3f;
    [Tooltip("reference for the ui canvas")]
    [SerializeField] UIDisplay uIDisplay;

    float waveUITimer = 1.5f;
    WaveConfigSO currentWave;
    Pathfinder pathfinder;
    int waveCount = 1;
    float startTimeRemaining = 0.0f;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
        startTimeRemaining = timeRemaining;
        uIDisplay.SetWaveText("Wave " + waveCount, true);
    }
    private void Update() 
    {
        if(waveUITimer > 0)
        {
            waveUITimer -= Time.deltaTime;
        }
        else
        {
            uIDisplay.SetWaveText("null", false);
        }
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            NextWave();
        }
    }

    void NextWave()
    {
        Debug.Log("time up");
        waveCount ++;
        uIDisplay.SetWaveText("Wave" + waveCount, true);
        waveUITimer = 1.5f;
        foreach(WaveConfigSO wave in waveConfigs)
        {
            wave.SetTimeBetweenEnemySpawns(timeAmountToTake);
        }
        timeRemaining = startTimeRemaining;
    }

   
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
    
    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartingPath().position,
                                Quaternion.Euler(0,0,180),
                                transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while(gameRunning);

    }
}
