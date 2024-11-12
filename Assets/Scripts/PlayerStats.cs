using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    public readonly int health;
    public readonly int mana;

    public PlayerStats(int health, int mana)
    {
        this.health = health;
        this.mana = mana;
    }

    public PlayerStats withHealth(int newHealth)
    {
        return new PlayerStats(newHealth, this.mana);
    }

    public PlayerStats withMana(int newMana)
    {
        return new PlayerStats(this.health, newMana);
    }
}
