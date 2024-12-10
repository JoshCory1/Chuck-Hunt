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
    [SerializeField] TextMeshProUGUI waveText;

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

    public void SetWaveText(string x, bool y)
    {
        if(y == true)
        {
            waveText.enabled = true;
        }
        waveText.text = x;
        if(y == false)
        {
            waveText.enabled = false;
        }
    }

    private void ScoreTracking()
    {
        if(scoreKeeper != null)
        {
            tmpScore.SetText(scoreKeeper.GetCurrentScore().ToString("000000000"));
        }
    }
}
