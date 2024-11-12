using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // GameManager properties and methods
    public int score = 0;

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }

    public void Start()
    {
        EventSystem.OnPlayerDeath += () => Debug.Log("Player is dead");
        EventSystem.OnCalculateSore += (baseScore) => baseScore * 2;
    }
}
