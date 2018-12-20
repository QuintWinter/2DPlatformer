using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int health = 30;

    AudioSource source;
    public AudioClip death;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void Kill(int damage)
    {
        health -= damage;
        
        print(health);

        if (health <= 0)
        {
            Invoke("Death", 0.5f);
        }
    }

    void Death()
    {
        PlayDeath();
        Invoke("Die", 0.5f);
    }

    void Die()
    { 
        Destroy(gameObject);
    }

    public void PlayDeath()
    {
        source.PlayOneShot(death);
    }

}
