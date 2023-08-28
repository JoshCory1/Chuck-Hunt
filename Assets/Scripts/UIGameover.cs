using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameover : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreFinalText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
   void Start()
   {
     scoreFinalText.text =  "You Scored :\n" + scoreKeeper.GetCurrentScore();
   }
}
