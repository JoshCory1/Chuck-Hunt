using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem explotion;
    [SerializeField] bool applyCameraShake;
    [SerializeField] bool isPlayer;
    [SerializeField] int score = 50;
    CameraShake camShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        camShake = Camera.main.GetComponent<CameraShake>();
    }
    public int GetHealth()
    {
        return health;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            audioPlayer.GettingHitClip();
            TakeDamage(damageDealer.GetDamage());
            Effect();
            ShakeCamera();
            damageDealer.Hit();
        }
    }
    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(!isPlayer)
        {
            scoreKeeper.IncraseScore(score);
        }
        Destroy(gameObject);
    }

    void Effect()
    {
        if(explotion != null)
        {
            ParticleSystem instance = Instantiate(explotion, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    void ShakeCamera()
    {
        if(camShake != null && applyCameraShake)
        {
            camShake.Play();
        }
    }
    
}
