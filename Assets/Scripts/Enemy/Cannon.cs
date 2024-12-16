using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    [SerializeField] private int direction;
    [SerializeField] private float cannonballSpeed;
    [SerializeField] private GameObject cannoballPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float randomMin = 0.3f;
    [SerializeField] private float randomMax = 1f;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Ignite()
    {
        animator.SetTrigger("shoot");
    }

    void Shoot()
    {
        GameObject cannonball = Instantiate(cannoballPrefab, shootPoint.position, shootPoint.rotation);
        cannonball.GetComponent<Rigidbody2D>().velocity = transform.right * cannonballSpeed * direction * Random.Range(randomMin, randomMax);
    }

}
