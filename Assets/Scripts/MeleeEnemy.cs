using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public override void Attack()
    {
        Debug.Log("Melee Enemy attacks!");
    }

    public override void Move()
    {
        Debug.Log("Melee Enemy goes towards the player");
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack();
        }
    }
}
