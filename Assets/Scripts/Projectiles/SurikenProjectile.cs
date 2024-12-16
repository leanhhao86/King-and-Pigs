using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SurikenProjectile : Projectile
{

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(9,6, true);

    }

    void Start()
    {
        Move();
        // Debug.Log("Projectile created");
        // Debug.Log("Target " +  target.x.ToString() + " " +  target.y.ToString());
    }

    void Update()
    {
        // Move();
    }

    public override void Move()
    {
        // Debug.Log("Suriken moving with speed " + speed);
        rigidBody.AddForce(new Vector2(speed * target.x, speed * target.y), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Colliding");
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);
            Destroy(this.gameObject);
        } else if (collision.gameObject.tag == "Enemy")
        {
            // Ignore the collision with the enemy
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }
        else
        {
            Destroy(this.gameObject);
        }


        
    }
}
