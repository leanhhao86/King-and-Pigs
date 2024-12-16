using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [Header ("BoxCast Parameters")]
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float range;
    [SerializeField] private float boxCastDistance;



    private Player player;

    void Awake()
    {
    }

    void Update()
    {
        
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
}
