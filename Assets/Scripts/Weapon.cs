using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int damage;
    public void Attack(IDamageable target)
    {
        Debug.Log(gameObject.name + " attacks for " + damage + " damage.");
        target.TakeDamage(damage);
    }
    public void Reload()
    {
        Debug.Log("Weapon Reloading");
    }
}
