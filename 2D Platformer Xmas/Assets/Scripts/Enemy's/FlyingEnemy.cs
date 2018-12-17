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
        randomVector2 = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
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


        if (distance < 6 && distance > 0.5f)
        {
            //ga naar de player positie
            Vector2 direction = player.transform.position - transform.position;
            SetDirection(direction);

            Vector2 positionP = transform.position;

            positionP += directionVector2 * speed * Time.deltaTime;

            transform.position = positionP;
        } else
        {
             transform.Translate(randomVector2 * Time.deltaTime * 0.5f);
        } 

        if(directionVector2.x >= 0)
        {
            animationB.SetBool("rechts", true);
        } else
        {
            animationB.SetBool("rechts", false);
        }

        if (directionVector2.x <= 0)
        {
            animationB.SetBool("links", true);
        }
        else
        {
            animationB.SetBool("links", false);
        }

        if (directionVector2.y >= 0 && directionVector2.x <= 1 || directionVector2.y >= 0 && directionVector2.x <= -1)
        {
            animationB.SetBool("voor", true);
        }
        else
        {
            animationB.SetBool("voor", false);
        }

        if (directionVector2.y <= 0 && directionVector2.x <= 1 || directionVector2.y <= 0 && directionVector2.x <= -1)
        {
            animationB.SetBool("achter", true);
        }
        else
        {
            animationB.SetBool("achter", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && counter <= 0)
        {
            counter = 1.5f;
        }
    }
}
