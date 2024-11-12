using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 25;
    }

    public virtual void Attack()
    {
        Debug.Log("Sword slashes for " + damage + " damage.");
    }
}
