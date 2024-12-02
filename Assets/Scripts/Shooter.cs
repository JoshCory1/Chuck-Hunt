using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Genral")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float fireRate = 0.2f;
    [Header ("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float timeBetweenShots = 1f;
    [SerializeField] float shotTimeVeriance = 0.5f;
    [SerializeField] float minimumShotTime = 0.2f;
    [SerializeField] GameObject builetExit;
    [HideInInspector] public bool isFiering;
    


    Coroutine fireingCoroutine;
    AudioPlayer audioPlayer;

    void Awake() 
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        AiFiering();
    }

    private void AiFiering()
    {
        if (useAI)
        {
            isFiering = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
       Fire(); 
    }

    private void Fire()
    {
        if(isFiering && fireingCoroutine == null)
        {
            fireingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiering && fireingCoroutine != null)
        {
            StopCoroutine(fireingCoroutine);
            fireingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {

            GameObject instance = Instantiate(projectilePrefab,
                                builetExit.transform.position,
                                Quaternion.identity);
                    Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
                    if(rb != null)
                    {
                        rb.velocity = transform.up * projectileSpeed;
                    }
                    Destroy(instance, projectileLifetime);
                    if(useAI)
                    {
                        fireRate = RandomShotTimer();
                    }
                    if(!useAI)
                    {
                        audioPlayer.PlayShootingClipPlayer();
                    }
                    if(useAI)
                    {
                        audioPlayer.PlayShootingClipEnemy();
                    }
            yield return new WaitForSeconds(fireRate);
        }               
            
    }
    float RandomShotTimer()
    {
        float spawnTime = UnityEngine.Random.Range(timeBetweenShots - shotTimeVeriance,
                                        timeBetweenShots + shotTimeVeriance);
        return Mathf.Clamp(spawnTime, minimumShotTime, float.MaxValue);
    }

}
