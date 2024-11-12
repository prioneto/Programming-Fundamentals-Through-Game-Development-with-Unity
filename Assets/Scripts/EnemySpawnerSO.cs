using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Services/EnemySpawner")]
public class EnemySpawnerSO : ScriptableObject, IEnemySpawner
{
    public GameObject enemyPrefab;

    public void SpawnEnemy(Vector3 position)
    {
        Instantiate(enemyPrefab, position, Quaternion.identity);
        Debug.Log("Enemy spawned at " + position);
    }
}
