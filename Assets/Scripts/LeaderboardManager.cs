using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LeaderboardManager : MonoBehaviour
{
    private List<int> scores = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        scores.Add(500);
        scores.Add(2000);
        scores.Add(750);
        scores.Add(100);
        scores.Add(900);
        scores.Add(5000);
        scores.Add(200);
        scores.Add(750);
        scores.Add(100);
        scores.Add(900);
        scores.Add(500);
        scores.Add(2000);
        scores.Add(750);
        scores.Add(100);
        scores.Add(9000);

        var topPlayers = scores.Where(p => p > 1000)
            .OrderByDescending(p => p)
            .Take(10);

        Debug.Log("Top Players: ");
        foreach (var player in topPlayers)
        {
            Debug.Log("Score: " + player);
        }

        /*DisplayScores("Unsorted Scores: ", scores);

        scores.Sort();
        scores.Reverse();


        DisplayScores("Sorted Scores: ", scores);*/

    }

    /*void DisplayScores(string title, List<int> scoresList)
    {
        Debug.Log(title);
        foreach (int score in scoresList)
        {
            Debug.Log(score);
        }
    }*/
}
