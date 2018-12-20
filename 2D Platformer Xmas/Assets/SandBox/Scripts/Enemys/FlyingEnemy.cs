using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{

    float distance;
    Vector2 directionVector2;
    Vector2 randomVector2;
    float speed = 1;
    float counter = 1.5f;
    float counters = 0;
    GameObject player;
    Animator animationB;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animationB = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 direction)
    {
        directionVector2 = direction.normalized;
    }

    void Update()
    {
        if(counter >= 0) { 
        counter -= Time.deltaTime;
        }
        //zoek naar de speler en krijg de afstand
        distance = Vector2.Distance(player.transform.position, gameObject.transform.position);


        if (distance < 20 && distance > 0.5f)
        {
            //ga naar de player positie
            Vector2 direction = player.transform.position - transform.position;
            SetDirection(direction);

            Vector2 positionP = transform.position;

            positionP += directionVector2 * speed * Time.deltaTime;

            transform.position = positionP;
        } 
    }
}
