using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [Header ("Attack Parameters")]
    [SerializeField] protected float attackCooldown;
    [SerializeField] protected int damage;

    [Header ("BoxCast Parameters")]
    [SerializeField] protected LayerMask playerLayer;
    [SerializeField] protected float range;
    [SerializeField] protected float yRange;
    [SerializeField] protected float boxCastDistance;
    [SerializeField] protected BoxCollider2D boxCollider;
    

    [SerializeField] protected int defaultDirection;
    
    
    private float cooldownTimer = Mathf.Infinity;
    public int currentDirection;

    // References
    protected Animator anim;
    protected Health health;
    protected Player player;
    protected SpriteRenderer spriteRenderer;
    protected EnemyPatrol enemyPatrol;


    void Awake()
    {
        anim = GetComponent<Animator>();
        currentDirection = defaultDirection;
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        health = GetComponent<Health>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
        // Attack only when see player
        if (PlayerInsight()) {
            if (cooldownTimer >= attackCooldown)
            {
                anim.SetTrigger("attack");
                cooldownTimer = 0;
            }
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInsight();
        }
    }

    public void ChangeDirection(int direction)
    {
        if (currentDirection != direction)
        {
            currentDirection = direction;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    public void MoveInDirection(int direction, float speed)
    {
        ChangeDirection(direction);
        transform.position = new Vector3(transform.position.x + Time.deltaTime * direction * speed,
                                    transform.position.y, transform.position.z);
    }

    public void WalkAnimation()
    {
        anim.SetBool("walk", true);
    }

    public void StopWalkAnimation()
    {
        anim.SetBool("walk", false);
    }

    virtual protected bool PlayerInsight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * boxCastDistance * currentDirection, 
            new Vector2(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y),
            0, 
            Vector2.left, 
            0, 
            playerLayer);

        if (hit.collider != null)
        {
            player = hit.transform.GetComponent<Player>();
        }

        return hit.collider != null;
    }

    public virtual void Attack()
    {
        if (PlayerInsight())
        {
            // Damage player health
            player.TakeDamage(damage);
        }
    }

    virtual protected void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * boxCastDistance * currentDirection, new Vector2(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y));
    }

    private void DestroyItself()
    {
        Destroy(this.gameObject);
    }
}
