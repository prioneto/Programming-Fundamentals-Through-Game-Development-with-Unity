using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEventArgs : MonoBehaviour
{
    public int damageAmount;

    public DamageEventArgs(int damage)
    {
        damageAmount = damage;
    }
}
