using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmpScore;
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;
    ScoreKeeper scoreKeeper;

    
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        healthSlider.maxValue = playerHealth.GetHealth();
        healthSlider.minValue = 0;
    }

    
    void Update()
    {
        ScoreTracking();
        healthSlider.value = playerHealth.GetHealth();
    }

    private void ScoreTracking()
    {
        if(scoreKeeper != null)
        {
            tmpScore.SetText(scoreKeeper.GetCurrentScore().ToString("000000000"));
        }
    }
}
