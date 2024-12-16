using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float waitTime;
    [SerializeField] private int damage;

    [Header ("Collider Parameters")]
    [SerializeField] private BoxCollider2D boxCollider;

    [Header ("BoxCast Parameters")]
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float range;
    [SerializeField] private float boxCastDistance;

    // References
    private Player player;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    void Start()
    {
        StartCoroutine(startAnimation());
    }

    public void DamagePlayer()
    {
        if (PlayerInsight())
        {
            // Damage player health
            player.TakeDamage(damage);
        }
    }

    private bool PlayerInsight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, 
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y));
    }

    private IEnumerator startAnimation()
    {
        yield return new WaitForSeconds(waitTime);
        animator.SetTrigger("start");
    }
}
