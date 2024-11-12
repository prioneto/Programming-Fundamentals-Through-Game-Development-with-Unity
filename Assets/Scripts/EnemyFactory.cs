using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Melee,
    Ranged
}

public class EnemyFactory : MonoBehaviour
{
    public GameObject meleeEnemyPrefab;
    public GameObject rangedEnemyPrefab;

    public GameObject CreateEnemy(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Melee:
                return Instantiate(meleeEnemyPrefab);
            case EnemyType.Ranged:
                return Instantiate(rangedEnemyPrefab);
            default:
                return null;
        }
    }
}
