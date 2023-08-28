using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int currentScore;
    static ScoreKeeper instance;

    void Awake()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void IncraseScore(int value)
    {
        currentScore += value;
        Mathf.Clamp(currentScore,0, int.MaxValue);
        Debug.Log(currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

}
