using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner : MonoBehaviour, IEnemySpawner
{
    public GameObject enemyPrefab;
    public int numberOfEnemies = 5;

    public Transform[] spawnPoints;

    private Queue<Vector3> spawnPositions = new Queue<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPosition = new Vector3(i * 2.0f, 0, 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }*/

        /*for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(enemyPrefab, spawnPoints[i].position, Quaternion.identity);
        }*/

        spawnPositions.Enqueue(new Vector3(0, 0, 10));
        spawnPositions.Enqueue(new Vector3(5, 0, 10));
        spawnPositions.Enqueue(new Vector3(-5, 0, 10));

        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy(Vector3 position)
    {
        Debug.Log("Enemy spawned at " + position);
    }

    IEnumerator SpawnEnemies()
    {
        while (spawnPositions.Count > 0)
        {
            Vector3 spawnPos = spawnPositions.Dequeue();
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            Debug.Log("Enemy spawned at: " + spawnPos);
            yield return new WaitForSeconds(2f); // Wait before spawning next enemy
        }
    }
}
