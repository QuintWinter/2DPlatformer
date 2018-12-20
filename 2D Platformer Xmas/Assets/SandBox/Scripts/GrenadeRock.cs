using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeRock : MonoBehaviour
{

    private float timer;
    private Collectibles coll;
    private float throwForce = 10;
    public GameObject popup;
    public GameObject granada;

    void Start()
    {
        coll = GetComponent<Collectibles>();
    }

    void Update()
    {
        if(coll.specialAttackMeter >= 5)
        {
            popup.SetActive(true);
        }
        else
        {
            popup.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (coll.specialAttackMeter >= 5)
            {
                print("nadeOut");
                coll.specialAttackMeter -= 5;
                GameObject insta = Instantiate(granada, this.transform);
                coll.score.text = coll.specialAttackMeter.ToString();

                insta.GetComponent<Rigidbody2D>().AddForce(granada.transform.right * throwForce, ForceMode2D.Impulse);
            }
        }
    }
}
