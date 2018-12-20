using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour {

    public float timer = 2;
    public CircleCollider2D radius;
    private ParticleSystem pickupSpoof;
    public LayerMask whatIsSolid;
    public float distance= 0.1f;

    void Start()
    {
        pickupSpoof = GetComponent<ParticleSystem>();
    }
    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            radius.GetComponent<CircleCollider2D>().enabled = true;
            pickupSpoof.Play(true);
        }

        if (timer <= -1)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            other.gameObject.GetComponent<AddToEnemy>().TakeDamage(10);
        }
    }


}
