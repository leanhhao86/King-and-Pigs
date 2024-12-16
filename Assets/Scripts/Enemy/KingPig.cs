using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingPig : Enemy
{

    [Header ("Projectile")]
    [SerializeField] private float projectileSpeed = 7f;
    [SerializeField] private GameObject surikenProjectilePrefab;
    [SerializeField] private int numberOfProjectile;

    [Header ("Movement")]
    [SerializeField] public Transform leftEdge;
    [SerializeField] public Transform rightEdge;
    [SerializeField] public float dashForce = 8f;
    [SerializeField] public float moveForce = 5f;


    // References
    private Rigidbody2D rigidbody;


    void Start()
    {
        // Ignore collision between enemy and platform
        Physics2D.IgnoreLayerCollision(6, 11, true);
        //Dash(-1);
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        currentDirection = defaultDirection;
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        health = GetComponent<Health>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    public void ThrowSuriken()
    {
        for (int j = 0; j < numberOfProjectile; j++)
        {
            GameObject surikenGameObject = Instantiate(surikenProjectilePrefab) as GameObject;
            SurikenProjectile projectile = surikenGameObject.GetComponent<SurikenProjectile>();
            // Normalize the value of y to make suriken spread out
            projectile.Init(transform.position, new Vector2(currentDirection, (float) j / (float) numberOfProjectile - 0.3f), projectileSpeed);
        }
    }


}
