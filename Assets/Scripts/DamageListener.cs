using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageListener : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    void OnEnable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnDamaged += OnDamaged;
        }
        else
        {
            Debug.LogError("Player health is not assigned!");
        }
    }

    void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnDamaged -= OnDamaged;
        }
    }

    void OnDamaged(object sender, DamageEventArgs e)
    {
        Debug.Log("Received damage: " + e.damageAmount);
    }

}
