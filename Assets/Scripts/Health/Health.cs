using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health: MonoBehaviour
{
    [SerializeField] private float maxHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        dead = false;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else 
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                dead = true;
                if (GetComponent<Player>() != null) 
                {
                    GetComponent<Player>().enabled = false;
                }
                else if (GetComponentInParent<EnemyPatrol>() != null)
                {
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                    GetComponent<Enemy>().enabled = false;
                } else if (GetComponent<Enemy>() != null)
                {
                    GetComponent<Enemy>().enabled = false;
                }
            }
        }
    }
}
