using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.Singleton;

public class ShootingFlyingEnemy : MonoBehaviour {

    float distance;
    Vector2 directionVector2;
    float timer;
    float speed = 1;
    public GameObject enemyProjectile;

    GameObject player;

    public void SetDirection(Vector2 direction)
    {
        directionVector2 = direction.normalized;
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        //timer voor schieten
        timer += Time.deltaTime;

        //zoek naar de speler en krijg de afstand
        distance = Vector2.Distance(player.transform.position, gameObject.transform.position);

        if (distance < 15 && distance > 4f)
        {
            //ga naar de player positie
            Vector2 direction = player.transform.position - transform.position;
            SetDirection(direction);

            Vector2 positionP = transform.position;

            positionP += directionVector2 * speed * Time.deltaTime;

            transform.position = positionP;
        }

        if (distance < 5 && timer > 3)
        {
            timer = 0;

            //instatiate laser
            GameObject projectile = Instantiate(enemyProjectile, transform.position, Quaternion.identity) as GameObject;

            //waar begint de laser
            projectile.transform.position = transform.position;

            //schiet de laser naar de speler plaats
            Vector2 direction = player.transform.position - projectile.transform.position;
            //laser.GetComponent<LaserBolt>().SetDirection(direction);
        }
    }
}
