using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Animator animator;

    [SerializeField] 
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float moveSpeed = 5f, 
        airSpeed = 2f,
        jumpPower = 10f,
        additionalGravity = 5f;

    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    private bool isGrounded, isFalling;

    private float inputX;

    // Update is called once per frame
    void Update()
    {
        isGrounded = CheckIfOnGround();
        isFalling = CheckIfIsFalling();



        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        inputX = Input.GetAxis("Horizontal");

        SetGraphics();
    }

    private void FixedUpdate()
    {

        var speed = isGrounded ? moveSpeed : airSpeed;
        rb.velocity = new Vector2(inputX * speed , rb.velocity.y);

        AddtionalGravity();
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
    }

    private void AddtionalGravity()
    {
        if(isFalling)
        {
            rb.AddForce(Vector2.down * additionalGravity);
        }
    }

    private void SetGraphics()
    {
        animator.SetBool("IsFalling", isFalling);
        animator.SetBool("IsMoving", rb.velocity.magnitude > 0.1f);
        animator.SetBool("IsJumping", rb.velocity.y > 0.1f);

        spriteRenderer.flipX = rb.velocity.x < 0;
    }

    private bool CheckIfOnGround()
    {
        var grounded = Physics2D.Raycast(transform.position - Vector3.up, Vector3.down, 0.5f, groundMask);
        return grounded;
    }

    private bool CheckIfIsFalling()
    {
        return rb.velocity.y < -0.2f;
    }

}
