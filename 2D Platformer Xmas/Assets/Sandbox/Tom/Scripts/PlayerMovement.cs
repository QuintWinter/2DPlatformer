using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private Vector2 targetVelocity;


    void Awake()
    {

    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        targetVelocity = move * maxSpeed;
    }
}
