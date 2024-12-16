using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerVerticalPlatform : MonoBehaviour
{
    [SerializeField] private float waitTime;

    private BoxCollider2D playerCollider;
    private Collider2D platformCollider;
    private GameObject platform;

    void Awake()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (platform)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            platform = collision.gameObject;
            platformCollider = collision.collider;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            platform = null;
        }
        
    }

    private IEnumerator DisableCollision()
    {
        Physics2D.IgnoreCollision(playerCollider, platformCollider, true);
        yield return new WaitForSeconds(waitTime);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }
}
