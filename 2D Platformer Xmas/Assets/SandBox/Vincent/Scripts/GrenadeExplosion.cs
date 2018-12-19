using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour {

    public float timer = 2;
    public CircleCollider2D radius;

	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            print("explode");
            radius.GetComponent<CircleCollider2D>().enabled = true;
        }

        if (timer <= -1)
        {
            Destroy(this.gameObject);
        }
	}
}
