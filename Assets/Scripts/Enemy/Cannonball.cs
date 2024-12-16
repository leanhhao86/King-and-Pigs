using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{

    [SerializeField] private int damage = 1;

    private Animator animator;
    private Rigidbody2D rigidbody2D;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Colliding");
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);
            animator.SetTrigger("explode"); // Explode on contact
        } else if (collision.gameObject.tag == "Enemy")
        {
            // Ignore the collision with the enemy
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
            animator.SetTrigger("explode"); // Explode on contact
        } else if (collision.gameObject.tag == "Platform")
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }
        else
        {
            animator.SetTrigger("explode"); // Explode on contact
        }


        
    }

    // For explosion animation
    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
