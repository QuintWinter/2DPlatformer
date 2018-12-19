using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour {

    public static Collectibles instace;
<<<<<<< HEAD:2D Platformer Xmas/Assets/SandBox/Scripts/Collectibles.cs
    public int specialAttackMeter = 0; 
=======
    public int specialAttackMeter = 20;
    private float timer = 3f;
>>>>>>> fccd9e6182d95aaa623c843957ae1f08920669fd:2D Platformer Xmas/Assets/SandBox/Vincent/Scripts/Collectibles.cs

    void Start()
    {
        instace = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "collectible")
        {
<<<<<<< HEAD:2D Platformer Xmas/Assets/SandBox/Scripts/Collectibles.cs
            Destroy(other.gameObject);
            specialAttackMeter++;
=======
            Collider2D colide = other.gameObject.GetComponent<Collider2D>();
            colide.enabled = false;

            StartCoroutine(WaitForSeconds(timer, other.gameObject));


>>>>>>> fccd9e6182d95aaa623c843957ae1f08920669fd:2D Platformer Xmas/Assets/SandBox/Vincent/Scripts/Collectibles.cs
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
