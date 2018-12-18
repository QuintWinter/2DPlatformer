using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int health = 30;

    public void Kill(int damage)
    {
        health -= damage;

        print(health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
