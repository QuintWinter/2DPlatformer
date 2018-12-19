using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour {

    public float timer = 2;
    public CircleCollider2D radius;
    private ParticleSystem pickupSpoof;

    void Start()
    {
        pickupSpoof = GetComponent<ParticleSystem>();
    }
    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            print("explode");
            radius.GetComponent<CircleCollider2D>().enabled = true;
            pickupSpoof.Play(true);
        }

        if (timer <= -1)
        {
            Destroy(this.gameObject);
        }
	}
}
