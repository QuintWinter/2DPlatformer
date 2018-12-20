using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {

    GameObject player;


    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider other)
    {
        SceneManager.LoadScene(0);
    }
}
