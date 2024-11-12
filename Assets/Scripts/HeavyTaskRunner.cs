using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class HeavyTaskRunner : MonoBehaviour
{
    private Thread backgroundThread;
    private bool isTaskCompleted = false;
    private float progress = 0f;
    private object progressLock = new object();

    void Start()
    {
        // Start the background thread
        backgroundThread = new Thread(new ThreadStart(HeavyTask));
        backgroundThread.Start();
    }

    void Update()
    {
        // Update the UI or perform actions based on progress
        if (backgroundThread != null && backgroundThread.IsAlive)
        {
            lock (progressLock)
            {
                Debug.Log("Progress: " + (progress * 100f).ToString("F2") + "%");
            }

        }
        else if (isTaskCompleted)
        {
            Debug.Log("Heavy task completed!");
            isTaskCompleted = false;
        }
    }

    void HeavyTask()
    {
        // Simulate a heavy computational task
        for (int i = 0; i <= 100; i++)
        {
            // Perform computation
            Thread.Sleep(1000); // Simulate work by sleeping

            // Update progress
            lock (progressLock)
            {
                progress = i / 100f;
            }
        }

        isTaskCompleted = true;
    }

    void OnApplicationQuit()
    {
        // Clean up the thread when the application quits
        if (backgroundThread != null && backgroundThread.IsAlive)
        {
            backgroundThread.Abort();
        }
    }
}
