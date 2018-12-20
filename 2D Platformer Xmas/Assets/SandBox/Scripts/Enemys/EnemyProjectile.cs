using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    Vector2 directionVector2;
    bool isReady = true;
    public float distance;
    public LayerMask whatIsSolid;

    private void Start()
    {
        Vector3 playerpos = GameObject.FindWithTag("Player").transform.position;

        playerpos.x = playerpos.x - transform.position.x;
        playerpos.y = playerpos.y - transform.position.y;

        float angle = Mathf.Atan2(playerpos.y, playerpos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    public void SetDirection(Vector2 direction)
    {
        isReady = true;
    }

    void FixedUpdate()
    {
        if (isReady == true)
        {
            transform.Translate(Vector2.right * Time.deltaTime * 10);
        }
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            DestroyProjectile();
        }

    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }


}
