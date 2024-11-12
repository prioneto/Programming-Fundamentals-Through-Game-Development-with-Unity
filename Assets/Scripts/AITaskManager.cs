using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITaskManager : MonoBehaviour
{

    private PriorityQueue<string> taskQueue = new PriorityQueue<string>();
    // Start is called before the first frame update
    void Start()
    {
        taskQueue.Enqueue("Collect Resources", 2);
        taskQueue.Enqueue("Defend Base", 1);
        taskQueue.Enqueue("Explore Area", 3);

        StartCoroutine(ExecuteTasks());
    }

    IEnumerator ExecuteTasks()
    {
        while (taskQueue.Count > 0)
        {
            string task = taskQueue.Dequeue();
            Debug.Log("Executing Task: " + task);
            // Simulate task execution time
            yield return new WaitForSeconds(2f);
        }
    }
}
