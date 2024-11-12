using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<int> OnHealthChanged;
    private int health = 100;

    public event EventHandler<DamageEventArgs> OnDamaged;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;

        //OnHealthChanged?.Invoke(health);
        OnDamaged?.Invoke(this, new DamageEventArgs(amount));

        if (health == 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Character has died.");
    }
}
