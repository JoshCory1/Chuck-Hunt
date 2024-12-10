using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting Player")]
    [SerializeField] AudioClip shootingClipPlayer;
    
    [Header ("Shooting Enemy")]
    [SerializeField] AudioClip shootingClipEnemy;

    [Header("Getting Hit")] 
    [SerializeField] AudioClip gettingHitClip;
    
    [Header("Volume SoundFX")]
    [SerializeField] [Range(0.0001f, 1.0f)] float soundFXVolume = 0.255f;
    static AudioPlayer instance;

    public AudioPlayer GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        // int instanceCount = FindSceneObjectsOfType(GetType()).Length;
        // if(instanceCount > 1)
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


    public void SetVolume(float x)
    {
        soundFXVolume = x;
    }
    
    private void ManageSingleton()
    {
        throw new NotImplementedException();
    }

    public void PlayShootingClipPlayer()
    {
        PlayClip(shootingClipPlayer, soundFXVolume);
    }

    public void PlayShootingClipEnemy()
    {
        PlayClip(shootingClipEnemy, soundFXVolume);
    }
    public void GettingHitClip()
    {
        PlayClip(gettingHitClip, soundFXVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
