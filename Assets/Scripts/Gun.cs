using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 10;
    }

    public virtual void Attack()
    {
        Debug.Log("Gun fires for " + damage + " damage.");
    }
}
