using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour
{

    float distance;
    float timer;
    public GameObject enemy1, enemy2;
    float enemyType;
    float shoottime = 2;

    GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        //timer voor schieten
        timer += Time.deltaTime;

        //zoek naar de speler en krijg de afstand
        if (timer > shoottime)
        {
            distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
            if (distance < 20)
            {
                if (timer > shoottime)
                {
                    timer = 0;
                    enemyType = Random.Range(0, 2);
                    if (enemyType == 1)
                    {
                        GameObject projectile = Instantiate(enemy1);
                        projectile.transform.position = transform.position;
                    }
                    else
                    {
                        GameObject projectile = Instantiate(enemy2);
                        projectile.transform.position = transform.position;

                    }

                }
            }
        }
    }
}
