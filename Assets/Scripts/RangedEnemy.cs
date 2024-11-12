using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public override void Attack()
    {
        Debug.Log("Ranged Enemy attacks!");
    }

    public override void Move()
    {
        Debug.Log("Ranged enemy keeps a distance");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack();
        }
    }
}
