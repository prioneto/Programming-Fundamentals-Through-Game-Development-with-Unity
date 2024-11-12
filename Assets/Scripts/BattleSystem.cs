using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int playerDamage = CombatCalculator.CalculateDamage(10, 5);
        int enemyDefense = CombatCalculator.CalculateDefense(8, 3);

        int damageDealt = Mathf.Max(0, playerDamage - enemyDefense);

        Debug.Log("Damage Dealt to Enemy: " +  damageDealt);
    }
}
