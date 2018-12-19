using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float checkRadius;
    private float moveInput;

    public int extraJumpValue;
    private int extraJumps;

    private bool isGrounded;

    public Transform groundCheck;
    public LayerMask whatIsGround;

    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    private void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0)
            sprite.flipX = false;
        else if (moveInput < 0)
            sprite.flipX = true;

        if (!isGrounded)
        {
            rb.velocity -= new Vector2(0, 15f * Time.deltaTime);
        }
    }

    private void Update()
    {
        if (isGrounded)
        {
            extraJumps = extraJumpValue;
        }
        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

}
