using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeRock : MonoBehaviour
{

    private float timer;
    private Collectibles coll;
    [SerializeField] private float throwForce = 10;

    public GameObject granada;

    void Start()
    {
        coll = GetComponent<Collectibles>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            timer += Time.deltaTime;
            print(timer);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (timer >= 2 && coll.specialAttackMeter >= 10)
            {
                print("nadeOut");
                timer = 0;
                coll.specialAttackMeter = coll.specialAttackMeter - 10;
                //throw grenade rock;
                GameObject insta = Instantiate(granada, this.transform);

                insta.GetComponent<Rigidbody2D>().AddForce(granada.transform.right * throwForce, ForceMode2D.Impulse);
                //thisproj.rigidbody2D.AddForce(thisproj.transform.forward * shootforce);
            }
            timer = 0;
        }
    }
}
