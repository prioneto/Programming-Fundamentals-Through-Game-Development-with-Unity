using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int enemiesPerWave = 5;
    public EnemyFactory enemyFactory;

    void Start()
    {
        StartCoroutine(SpawnWaves());
        //SpawnEnemies();

        var weakEnemies = enemies.Where(e => e.health < 50).ToList();

        Debug.Log("Weak Enemies");
        foreach(var enemy in weakEnemies)
        {
            Debug.Log(enemy.name + " - Health: " + enemy.health);
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < 5; i++)
        {
            EnemyType type = (i % 2 == 0) ? EnemyType.Melee : EnemyType.Ranged;
            GameObject enemy = enemyFactory.CreateEnemy(type);
            enemy.transform.position = new Vector3(i * 2.0f, 0, 0);
        }
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                int spawnIndex = Random.Range(0, spawnPoints.Length);
                GameObject enemyobj = Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
                Enemy enemy = enemyobj.GetComponent<Enemy>();
                enemies.Add(enemy);
            }
            yield return new WaitForSeconds(10f);
        }
    }

    private void Update()
    {
        
    }
}
