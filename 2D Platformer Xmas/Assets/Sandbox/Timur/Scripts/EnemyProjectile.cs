using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    //float speed = 2.7f;
    Vector2 directionVector2;
    bool isReady = true;

    private void Start()
    {
        Vector3 playerpos = GameObject.FindWithTag("Player").transform.position;

        //Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        playerpos.x = playerpos.x - transform.position.x;
        playerpos.y = playerpos.y - transform.position.y;

        float angle = Mathf.Atan2(playerpos.y, playerpos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Awake()
    {
        //isReady = false;
    }

    public void SetDirection(Vector2 direction)
    {
        //directionVector2 = direction.normalized;
        

        isReady = true;
    }

    void FixedUpdate()
    {
        if (isReady == true)
        {
            //Vector2 position = transform.position;

            //position += directionVector2 * speed * Time.deltaTime;

            //transform.position = position;

            transform.Translate(Vector2.right * Time.deltaTime * 3);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
            Destroy(gameObject);
    }

}
