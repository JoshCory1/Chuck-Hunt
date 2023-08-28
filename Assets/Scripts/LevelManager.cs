using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float delayLoadLevel = 2f;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LodeGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene(1);
    }

     public void LodeMainMenu()
    {
        SceneManager.LoadScene(0);
    }

     public void LodeGameOver()
    {
        StartCoroutine(WaitAndLoad(2, delayLoadLevel));
    }

    public void QuitGame()
    {
       Debug.Log("Quiting");
        Input.backButtonLeavesApp = true;
        Application.Quit();
    }

    IEnumerator WaitAndLoad(int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(index);
    }
}
