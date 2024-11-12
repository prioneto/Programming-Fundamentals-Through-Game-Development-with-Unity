using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameState gameState;

    public EnemySpawnerSO enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawner.SpawnEnemy(Vector3.zero);
        gameState = new GameState(1, 0);
        Debug.Log("Initial Game State - Level: " + gameState.level + ", Experience: " + gameState.experience);

        // Simulate gaining experience
        gameState = gameState.AddExperience(100);
        Debug.Log("After Gaining Experience - Level: " + gameState.level + ", Experience: " + gameState.experience);

        // Level up
        gameState = gameState.LevelUp();
        Debug.Log("After Level Up - Level: " + gameState.level + ", Experience: " + gameState.experience);
    }
}
