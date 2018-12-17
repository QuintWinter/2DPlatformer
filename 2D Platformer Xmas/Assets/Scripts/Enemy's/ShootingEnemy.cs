using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour {

    float distance;
    float timer;
    public GameObject enemyProjectile;

    float shoottime = 0.6f;

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
        if(timer > shoottime) {
            distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
            if (distance < 7.5f)
            {
                if (timer > shoottime)
                {
                    timer = 0;

                    //instatiate projectile
                    GameObject projectile = Instantiate(enemyProjectile);

                    //projectile.transform.SetParent(GameObject.Find("BoltObj").transform);
                    //waar begint de projectile
                    projectile.transform.position = transform.position;

                    //schiet de projectile naar de speler plaats
                    Vector2 direction = player.transform.position - projectile.transform.position;
                    projectile.GetComponent<EnemyProjectile>().SetDirection(direction);
                    //Destroy(projectile, 3.5f);
                }
            }
        }
    }
}
