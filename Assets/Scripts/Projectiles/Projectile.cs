using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected Vector2 target;
    protected Rigidbody2D rigidBody;
    protected float speed = 0;
    protected int damage = 1;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    public void Init(Vector3 position, Vector2 targetPosition, float movementSpeed)
    {
        transform.position = position;
        target = targetPosition;
        speed = movementSpeed;
        // Debug.Log("Initing projectile " + target.ToString());
    }

    public virtual void Move()
    {

    }



}
