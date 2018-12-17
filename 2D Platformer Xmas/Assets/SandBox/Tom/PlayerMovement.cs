using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed;
    public float jumpTakeOffSpeed;

    private Vector2 targetVelocity;


    void Awake()
    {

    }

    void Movement()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        targetVelocity = move * maxSpeed;
    }
}
