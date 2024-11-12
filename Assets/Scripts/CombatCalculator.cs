using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCalculator
{
    public static int CalculateDamage(int baseDamage, int strength)
    {
        return baseDamage + (strength * 2);
    }

    public static int CalculateDefense(int baseDefense, int agility)
    {
        return baseDefense + (agility * 1);
    }
}
