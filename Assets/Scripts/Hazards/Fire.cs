using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [Header ("Parameters")]
    [SerializeField] private int damage;
    [SerializeField] private float waitTime;

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

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Fire triggered");
        if (collider.gameObject.tag == "Player"){
            player = collider.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);  
        }
    }

    private IEnumerator startAnimation()
    {
        yield return new WaitForSeconds(waitTime);
        animator.SetTrigger("start");
    }
}
