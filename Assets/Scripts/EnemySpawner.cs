using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool gameRunning = true;
    [SerializeField] float timeRemaining = 30f;
    [SerializeField] float timeAmountToTake = 0.1f;
    WaveConfigSO currentWave;
    float startTimeRemaining = 0.0f;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
        startTimeRemaining = timeRemaining;
    }

    private void Update() 
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Debug.Log("time up");
            foreach(WaveConfigSO wave in waveConfigs)
            {
                wave.SetTimeBetweenEnemySpawns(timeAmountToTake);
            }
            timeRemaining = startTimeRemaining;
        }
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
