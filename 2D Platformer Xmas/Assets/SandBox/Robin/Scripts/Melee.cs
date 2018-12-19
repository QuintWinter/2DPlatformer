using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public int damage = 10;

    public float Cooldown, CooldownTime = 0.3f;

    public float distance = 2f;
    public float speed = 5f;

    public Vector2 vector;

    SoundManagerPlayer smp;

    private void Awake()
    {
        smp = GetComponent<SoundManagerPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        //simple movement.
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(x, 0, 0);

        if (Cooldown <= 0)
        {

            //Raycast
            if (Input.GetKeyDown(KeyCode.S))
            {
                RaycastHit2D hit = Physics2D.Raycast(vector = new Vector2(transform.position.x, transform.position.y), Vector2.right, distance);

                //Check if Ray hits a Collider that has the tag "Enemy"
                if (hit.collider != null && hit.collider.tag == "Enemy")
                {
                    smp.PlayHit();

                    //call Kill function from EnemyController script.
                    EnemyController enemy = hit.collider.gameObject.GetComponent<EnemyController>();
                    enemy.Kill(damage);
                }
                Cooldown = CooldownTime;
            }
        }

        else
        {
            Cooldown -= Time.deltaTime;
        }
    }
}
    
