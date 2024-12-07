using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName ="New Wave Config")]

public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float startTimeBetweenEnemySpawns = 1.5f;
    [SerializeField] float spawnTimeVeriance = 1f;
    [SerializeField] float minimumSpawnTime = 0.2f;
    float timeBetweenEnemySpawns = 1.5f;
    void Start()
    {
        timeBetweenEnemySpawns = startTimeBetweenEnemySpawns;
    }
    public void SetTimeBetweenEnemySpawns(float reduceTime)
    {
        timeBetweenEnemySpawns -= reduceTime;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
    public Transform GetStartingPath()
    {
        return pathPrefab.GetChild(0);
    }
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
       return enemyPrefabs[index];
    }
    public float GetRandomSpawnTime()
    {
        float spawnTime = UnityEngine.Random.Range(timeBetweenEnemySpawns - spawnTimeVeriance,
                                        timeBetweenEnemySpawns + spawnTimeVeriance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }

    
}
