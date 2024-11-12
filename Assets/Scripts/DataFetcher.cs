using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class DataFetcher : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        Debug.Log("Fetching data...");
        string result = await FetchDataAsync();
        Debug.Log("Data received: " + result);
    }

    async Task<string> FetchDataAsync()
    {
        await Task.Delay(2000);

        return "Sample data";
    }
}
