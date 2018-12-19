using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    public bool flipped;

    public Vector3 currRot;

    Transform enemyTrans;

    public Rigidbody2D enemyBody;

    private void Start()
    {
        enemyTrans = this.transform;
        enemyBody = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 enemyVel = enemyBody.velocity;
        enemyVel.x = -enemyTrans.right.x * speed;
        enemyBody.velocity = enemyVel;
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
}
