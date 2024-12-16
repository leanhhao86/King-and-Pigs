using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonPig : Enemy
{
    [Header ("Cannon Parameters")]

    [SerializeField] private Cannon cannon;


    override protected bool PlayerInsight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * boxCastDistance * currentDirection, 
            new Vector2(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * yRange),
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

    override protected void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * boxCastDistance * currentDirection, new Vector2(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * yRange));
    }

    void IgniteCannon()
    {
        cannon.Ignite();
    }

    override public void Attack()
    {
        // Start the match lighting to ignite cannon
        anim.SetTrigger("lightmatch");
    }
    
}
