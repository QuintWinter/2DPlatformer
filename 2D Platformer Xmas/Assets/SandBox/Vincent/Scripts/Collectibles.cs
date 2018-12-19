using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour {

    public static Collectibles instace;
    public int specialAttackMeter = 20;
    private float timer = 3f;

    void Start()
    {
        instace = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("collider hit");
        if (other.gameObject.CompareTag("collectible"))
        {
            Collider2D colide = other.gameObject.GetComponent<Collider2D>();
            colide.enabled = false;

            StartCoroutine(WaitForSeconds(timer, other.gameObject));


        }
    }

    IEnumerator WaitForSeconds(float t, GameObject gameObject)
    {
        yield return new WaitForSeconds(t);
        gameObject.SetActive(false);
        specialAttackMeter++;
        print(specialAttackMeter);
    }
}
