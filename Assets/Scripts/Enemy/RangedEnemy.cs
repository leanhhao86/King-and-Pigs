using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [Header ("Projectile")]
    [SerializeField] private float projectileSpeed = 7f;
    [SerializeField] private GameObject surikenProjectilePrefab;
    public override void Attack()
    {
        GameObject surikenGameObject = Instantiate(surikenProjectilePrefab) as GameObject;
        SurikenProjectile projectile = surikenGameObject.GetComponent<SurikenProjectile>();
        // Debug.Log(projectile);
        projectile.Init(transform.position, new Vector2(currentDirection, 0), projectileSpeed);
    }
}
