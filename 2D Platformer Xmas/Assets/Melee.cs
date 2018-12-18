using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour {

    public float distance = 10f;
    public bool front = true;
    public float speed = 5f;
    public Vector2 vector;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        //simple movement.
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(x, 0, 0);

        
        //Raycast
        if (Input.GetKeyDown(KeyCode.S))
        {
                RaycastHit2D hit = Physics2D.Raycast(vector = new Vector2(transform.position.x, transform.position.y), Vector2.right, distance);

            //Check if Ray hits a Collider
            if (hit.collider != null && hit.collider.tag == "Enemy")
            {
                //call Kill function from EnemyController script.
                EnemyController enemy = hit.collider.gameObject.GetComponent<EnemyController>();
                enemy.Kill();
            }
        }
    }
}
