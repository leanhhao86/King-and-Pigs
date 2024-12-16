using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public bool onGround = true;
    [Header ("Movement parameters")]
    [SerializeField] private int defaultDirection;
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 11f;

    [Header ("Collider Parameters")]
    [SerializeField] private BoxCollider2D boxCollider;

    [Header ("Box Cast parameters")]
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float range;
    [SerializeField] private float boxCastDistance;

    [Header ("iFrames")]
    [SerializeField] private float iframeDuration;
    [SerializeField] private int numberOfFlashes;

    // References
    private float movementInput;
    private Rigidbody2D myBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private string WALK_ANIMATION = "walk";
    private int currentDirection;
    private bool vulnerable; // Player not affected by damage
    //private string JUMP_ANIMATION = "jump";

    private Health health;
    private Health enemyHealth;


    private void Awake() 
    {        
        currentDirection = defaultDirection;
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
        vulnerable = true;
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveKeyboard(); 
        AnimatePlayer();
        Jump(); 
        Attack();
    }

    void FixedUpdate()
    {
        
    }

    void MoveKeyboard()
    {
        movementInput = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementInput, 0f, 0f) * Time.deltaTime  * moveForce;
    }

    void AnimatePlayer()
    {
        movementInput = Input.GetAxisRaw("Horizontal");
        if (movementInput > 0) 
        {
            spriteRenderer.flipX = false;
            animator.SetBool(WALK_ANIMATION, true);
            currentDirection = 1;
        }    
        else if (movementInput < 0) 
        {
            spriteRenderer.flipX = true;
            animator.SetBool(WALK_ANIMATION, true);
            currentDirection = -1;
        }    
        else
        {
            animator.SetBool(WALK_ANIMATION, false);
        }   
    }

    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && onGround) 
        {
            onGround = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            // animator.SetBool(JUMP_ANIMATION, true);
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("attack");
            if (EnemyInSight())
            {
                enemyHealth.TakeDamage(1);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (vulnerable)
        {
            health.TakeDamage(damage);
            StartCoroutine(Invulnerable());
        }

    }

    private bool EnemyInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * boxCastDistance * currentDirection, 
            new Vector2(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y),
            0, 
            Vector2.left, 
            0, 
            enemyLayer);

        if (hit.collider != null)
        {
            enemyHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * boxCastDistance * currentDirection, 
            new Vector2(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y));
    }


    private IEnumerator Invulnerable()
    {
        // Physics2D.IgnoreLayerCollision(3, 8, true);
        vulnerable = false;
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iframeDuration / (numberOfFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iframeDuration / (numberOfFlashes * 2));
        }
        vulnerable = true;
        // Physics2D.IgnoreLayerCollision(3, 8, false);
    }
}
