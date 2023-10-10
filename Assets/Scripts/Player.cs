using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 5f, airSpeed = 2f;
    [SerializeField]
    private float jumpPower = 10f;
    [SerializeField]
    private LayerMask groundMask;

    private bool isGrounded;

    private float inputX;

    // Update is called once per frame
    void Update()
    {
        isGrounded = CheckIfOnGround();

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        inputX = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()
    {

        var speed = isGrounded ? moveSpeed : airSpeed;
        rb.velocity = new Vector2(inputX * speed , rb.velocity.y);


    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
    }

    private bool CheckIfOnGround()
    {
        var grounded = Physics2D.Raycast(transform.position - Vector3.up, Vector3.down, 0.5f, groundMask);
        return grounded;
    }
}
