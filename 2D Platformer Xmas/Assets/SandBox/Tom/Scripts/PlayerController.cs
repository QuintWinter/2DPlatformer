using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public GameObject ps;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < -0.01f));
        /*
        if (move.x > 0.01f || move.x < -0.01f)
        {
            ps.SetActive(true);
        }
        else
        {
            ps.SetActive(false);
        }
        */
        /*
        if (move.x > 0.01f)
        {
            turn.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            turn.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        */
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}
