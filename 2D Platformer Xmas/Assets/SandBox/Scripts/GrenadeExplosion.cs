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

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                //laat enemy damage krijgen
                Debug.Log("take damage");
                hitInfo.collider.GetComponent<AddToEnemy>().TakeDamage(10);
            }
        }
    }
}
