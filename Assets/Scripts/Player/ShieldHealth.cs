using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHealth : MonoBehaviour, IDamageable
{

    [SerializeField]
    [Range(1,50)] private int health = 20;

    private PlayerHealth playerHealth;

    private void Update()
    {
        if(playerHealth == null)
        {
            playerHealth = GetComponentInParent<PlayerHealth>();
            playerHealth.enabled = false;
        }        
    }

    public void Die()
    {
        playerHealth.enabled = true;
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {        
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
}
