using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting Player")]
    [SerializeField] AudioClip shootingClipPlayer;
    [SerializeField] [Range(0f, 1f)] float shootingVolumePlayer = 1f;

    [Header ("Shooting Enemy")]
    [SerializeField] AudioClip shootingClipEnemy;
    [SerializeField] [Range(0f, 1f)] float shootingVolumeEnemy = 1f;

    [Header("Getting Hit")] 
    [SerializeField] AudioClip gettingHitClip;
    [SerializeField] [Range(0f, 1f)] float hitVolume = 1f;




    public void PlayShootingClipPlayer()
    {
        PlayClip(shootingClipPlayer, shootingVolumePlayer);
    }

    public void PlayShootingClipEnemy()
    {
        PlayClip(shootingClipEnemy, shootingVolumeEnemy);
    }
    public void GettingHitClip()
    {
        PlayClip(gettingHitClip, hitVolume);
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
