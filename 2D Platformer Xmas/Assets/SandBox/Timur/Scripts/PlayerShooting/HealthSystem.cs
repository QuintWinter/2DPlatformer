using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour {

    int health = 4;
    float timer = 3;
    public Image[] hearts;
    public Sprite emptyHeart, fullHeart;

    private void Update()
    {
        timer += Time.deltaTime;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && timer >= 3)
        {
            health -= 1;
            timer = 0;
            if(health <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
