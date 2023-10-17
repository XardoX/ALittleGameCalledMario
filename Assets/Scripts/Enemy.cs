using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float rayDistance = 1f;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private Vector3 moveDirection = Vector2.right;

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if(Physics2D.Raycast(transform.position, moveDirection,rayDistance,layerMask))
        {
            moveDirection *= -1;

            spriteRenderer.flipX = moveDirection.x > 0 ? true : false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
