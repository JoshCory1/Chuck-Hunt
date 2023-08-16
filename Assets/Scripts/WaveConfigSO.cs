using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "WaveConfigSO Config", fileName ="New Wave Config")]

public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }
    public Transform GetStartingPath()
    {
        return pathPrefab.GetChild(0);
    }
    
}
