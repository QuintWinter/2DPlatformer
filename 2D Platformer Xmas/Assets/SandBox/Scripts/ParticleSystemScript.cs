using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScript : MonoBehaviour {

    private ParticleSystem pickupSpoof;

    void Start()
    {
        pickupSpoof = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("active");
            pickupSpoof.Play(true);
            print("active");
        }
    }
}
