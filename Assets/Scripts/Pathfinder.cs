using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawnr;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;
    void Awake() 
    {
        enemySpawnr = FindObjectOfType<EnemySpawner>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        waveConfig = enemySpawnr.GetCurrentWave();
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        Falowpath();
    }

    private void Falowpath()
    {
        if(waypointIndex < waypoints.Count)
        {
           Vector3 targetPosition = waypoints[waypointIndex].position;
           float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
           transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);
           if(transform.position == targetPosition)
           {
            waypointIndex++;
           }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
