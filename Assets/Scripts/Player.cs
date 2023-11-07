using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    private ParticleSystem jumpParticle;

    [SerializeField]
    private float moveSpeed = 5f, 
        airSpeed = 2f,
        jumpPower = 10f,
        additionalGravity = 5f;

    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    private float groundRayDistance = 0.2f;

    [SerializeField]
    private bool isGrounded, isFalling;

    [SerializeField]
    private Vector2 jumpStretchScale = new Vector3(0.9f, 1.3f, 1f),
        jumpSqueezeScale = new Vector3(1.3f, 0.6f, 1f);

    [SerializeField]
    private float jumpStretchDuration = 0.2f,
        jumpSqueezeDuration = 0.1f;

    private bool lastFrameIsGrounded;

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

    private void LateUpdate()
    {
        lastFrameIsGrounded = isGrounded;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        jumpParticle.Play();
        transform.DOScale(jumpStretchScale, jumpStretchDuration).SetEase(Ease.OutQuint);
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
        var grounded = Physics2D.Raycast(transform.position - Vector3.up, Vector3.down, groundRayDistance, groundMask);

        if(grounded && lastFrameIsGrounded == false) //pierwsza klatka na ziemi
        {
            Debug.Log("First Frame On ground");
            transform.DOScale(jumpSqueezeScale, jumpSqueezeDuration).SetEase(Ease.OutQuint)
                .OnComplete(() => transform.DOScale(1f, 0.15f)).SetEase(Ease.OutQuint);
        }
        else if(grounded == false && lastFrameIsGrounded) //pierwsza klatka w powietrzu
        {
            Debug.Log("First Frame in air");

        }
        return grounded;
    }

    private bool CheckIfIsFalling()
    {
        return rb.velocity.y < -0.2f;
    }

}
