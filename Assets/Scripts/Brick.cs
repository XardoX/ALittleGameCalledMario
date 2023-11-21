using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Collider2D coll;

    [SerializeField]
    private ParticleSystem particleSystem;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            if(collision.collider.transform.position.y < transform.position.y - coll.bounds.extents.y)
            {
                animator.SetTrigger("Hit");
                particleSystem.Play();
            }
        }
    }
}
