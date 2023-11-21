using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private CircleCollider2D circleCollider;

    [SerializeField]
    private ParticleSystem explosionParticle;

    public void Shoot(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameManager.Instance.RespawnPlayer();
            StartCoroutine(Explode());
        }

        if(collision.collider.CompareTag("Enemy"))
        {
            collision.collider.GetComponent<Enemy>().KillEnemy();
            StartCoroutine(Explode());

        }
        if (collision.contacts[0].point.y > transform.position.y - circleCollider.radius )
        {
            StartCoroutine(Explode());
        }
        Debug.Log(collision.gameObject.name + " " + transform.position +" "+ collision.contacts[0].point);

    }

    private IEnumerator Explode()
    {
        explosionParticle.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
