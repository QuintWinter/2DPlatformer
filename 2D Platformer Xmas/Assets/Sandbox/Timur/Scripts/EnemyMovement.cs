using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    public float PlayerH;
    public float timer = 0.0f;
    public bool flipped;

    public SpriteRenderer sr;

    public PlayerController pc;

    public Vector3 currRot;

    public float timeDamage = 0;

    public Color lerpedColor = Color.white;

    Transform enemyTrans;

    public Rigidbody2D enemyBody;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        enemyTrans = this.transform;
        enemyBody = this.GetComponent<Rigidbody2D>();
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void DamageTimer()
    {
        timeDamage -= Time.deltaTime;

        if (timeDamage <= 0)
            timeDamage = 0;
    }

    private void FixedUpdate()
    {
        DamageTimer();
        Vector2 enemyVel = enemyBody.velocity;
        enemyVel.x = -enemyTrans.right.x * speed;
        enemyBody.velocity = enemyVel;
        timer += Time.deltaTime;
        if (timer >= 0.2f)
        {
            Color newColor = new Color(Random.value, 0, 0, 1.0f);
            lerpedColor = Color.Lerp(Color.white, newColor, Mathf.PingPong(Time.time, 1));
            sr.color = newColor;
            timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "TurnPoint")
        {
            currRot = enemyTrans.eulerAngles;
            currRot.y += 180;
            enemyTrans.eulerAngles = currRot;
        }
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            timeDamage = 1;
            if (!flipped)
            {
                enemyBody.AddForce(-transform.right * PlayerH);
            }
            else if (flipped)
            {
                enemyBody.AddForce(transform.right * PlayerH);
            }

            hit.gameObject.GetComponent<PlayerController>();
        }
    }
}
