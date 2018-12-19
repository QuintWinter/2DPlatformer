using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour {

    public static Collectibles instace;
    public int specialAttackMeter = 0; 

    void Start()
    {
        instace = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "collectible")
        {
            Destroy(other.gameObject);
            specialAttackMeter++;
        }
    }
}
