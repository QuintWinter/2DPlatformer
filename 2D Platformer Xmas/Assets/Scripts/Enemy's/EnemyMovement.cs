using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //PlayerController pControl;
    //GameObject Player;
    // hier maken we een float aan voor de snelheid van de enemy
    public float speed = 1f;
    public float PlayerH;
    public float timer = 0.0f;
    public bool flipped;

    public SpriteRenderer sr;

    public Life life;
    public PlayerController pc;
    public GameStateManager gameStateManagerScript;

    public Vector3 currRot;

    public float timeDamage = 0;

    public Color lerpedColor = Color.white;

    AudioSource aSource;
    AudioClip clip1;
    AudioClip clip2;

    // hier maken we een Transform aan voor de enemy
    Transform enemyTrans;

    // hier maken we een 2D rigidbody aan voor de enemy
    public Rigidbody2D enemyBody;
    //Life life;

    // Use this for initialization
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        // hier pakken we het PlayerController script van de Player
        //Player = GameObject.Find("Player");
        //pControl = Player.GetComponent<PlayerController>();
        // hier assignen we de enemy transfom aan de transform van het object waar dit script op zit
        enemyTrans = this.transform;
        // hier assignen we enemy rigidbody2D van het object waar dit script op zit
        enemyBody = this.GetComponent<Rigidbody2D>();
        gameStateManagerScript = FindObjectOfType<GameStateManager>();
        aSource = GetComponent<AudioSource>();
        clip1 = Resources.Load<AudioClip>("ground hit");
        clip2 = Resources.Load<AudioClip>("CLAP");
        //ps = GetComponent<ParticleSystem>();
        life = GameObject.Find("Player").transform.GetChild(1).GetComponent<Life>();
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void DamageTimer()
    {
        timeDamage -= Time.deltaTime;

        if (timeDamage <= 0)
            timeDamage = 0;
    }

    // FixedUpdate is called once per frame
    private void FixedUpdate()
    {
        DamageTimer();
        // hier maken we een Vector2 aan voor de velocity van de enemy
        Vector2 enemyVel = enemyBody.velocity;
        // hier geven we de enemy snelheid
        enemyVel.x = -enemyTrans.right.x * speed;
        // hier zetten we de rigidbody2D van gelijk aan de velocity
        enemyBody.velocity = enemyVel;
        timer += Time.deltaTime;
        if (timer >= 0.2f)
        {
            Color newColor = new Color(Random.value, 0, 0, 1.0f);
            lerpedColor = Color.Lerp(Color.white, newColor, Mathf.PingPong(Time.time, 1));
            sr.color = newColor;
            timer = 0;
        }
        //Debug.Log(enemyBody.velocity);
    }

    // hier maken we een OnTriggerEnter2D aan voor de turn points
    private void OnTriggerEnter2D(Collider2D coll)
    {
        // hier maken we een if statement om te kijken of we collision hebben met een turn point
        if (coll.gameObject.tag == "TurnPoint")
        {
            // hier maken we een vector3 aan voor de rotatie van de enemy
            currRot = enemyTrans.eulerAngles;
            // hier rotaten we de enemy met 180 graden
            currRot.y += 180;
            enemyTrans.eulerAngles = currRot;
        }
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            life.Damage();
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
            hit.gameObject.transform.GetChild(1).GetComponent<Life>().Damage();
            StartCoroutine(pc.ColourHit());
            aSource.PlayOneShot(clip2);
            Debug.Log("Damage");
        }
    }
}
