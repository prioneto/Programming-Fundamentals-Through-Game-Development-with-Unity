using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyFinder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var hurtEnemies = from enemy in FindObjectsOfType<Enemy>()
                          where enemy.health <= 50
                          select enemy;

        Debug.Log("Hurt Enemies:");
        foreach (var enemy in hurtEnemies)
        {
            Debug.Log("Hurt Enemy: " + enemy.name);
        }
    }
}
