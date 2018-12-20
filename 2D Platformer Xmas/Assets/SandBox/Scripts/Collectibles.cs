using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour {

    public static Collectibles instace;
    public int specialAttackMeter = 0;
    private float timer = 3f;
    public Text score;
    AudioSource AS;
    public AudioClip pickup;

    void Start()
    {
        instace = this;
        AS = GetComponent<AudioSource>();
    }

    IEnumerator WaitForSeconds(float t, GameObject woGameobject)
    {
    yield return new WaitForSeconds(t);
        Destroy(woGameobject);
        specialAttackMeter++;
        score.text = specialAttackMeter.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("collectible"))
        {
            AS.PlayOneShot(pickup);
            StartCoroutine(WaitForSeconds(0.01f, other.gameObject));


        }
    }
}
