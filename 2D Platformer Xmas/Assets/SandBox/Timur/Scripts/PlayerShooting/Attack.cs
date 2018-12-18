using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    float baseangle;

    public bool isCurrentlyInAAttack = false;
    int currentAttack = 0;

    float timer;

    private GameObject objectToDestroy;

    public GameObject playerProjectile;

    Quaternion rotation;

    GameObject hudManager;

    void Start()
    {
        hudManager = GameObject.FindWithTag("HUDManager");
    }
	
	void Update () {
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        baseangle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(baseangle, Vector3.forward);

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    void ShootGun()
    {
            GameObject bullet = Instantiate(playerProjectile, transform.position, Quaternion.identity);
            timer = 0.2f;
            currentAttack = 2;
    }
}
