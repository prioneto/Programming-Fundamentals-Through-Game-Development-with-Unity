using UnityEngine;
using System.Threading;

public class TerrainGenerator : MonoBehaviour
{
    private Thread generationThread;
    private float[,] heightMap;
    private bool isGenerationCompleted = false;

    void Start()
    {
        generationThread = new Thread(new ThreadStart(GenerateTerrainData));
        generationThread.Start();
    }

    void Update()
    {
        if (isGenerationCompleted)
        {
            BuildTerrain();
            isGenerationCompleted = false;
        }
    }

    void GenerateTerrainData()
    {
        int width = 100;
        int height = 100;
        heightMap = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Simple noise function
                heightMap[x, y] = Mathf.PerlinNoise(x * 0.1f, y * 0.1f);
            }
        }

        isGenerationCompleted = true;
    }

    void BuildTerrain()
    {
        // Use the heightMap to build Unity terrain or mesh
        // This must be done on the main thread
        Debug.Log("Terrain generation completed. Building terrain...");
        // Implementation of terrain building goes here
    }

    void OnApplicationQuit()
    {
        if (generationThread != null && generationThread.IsAlive)
        {
            generationThread.Abort();
        }
    }
}
