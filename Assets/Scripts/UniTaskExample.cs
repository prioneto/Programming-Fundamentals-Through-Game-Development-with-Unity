using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class UniTaskExample : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        Debug.Log("Fetching data...");
        string result = await FetchDataAsync();
        Debug.Log("Data received: " + result);
    }

    async UniTask<string> FetchDataAsync()
    {
        await UniTask.Delay(2000);

        return "Sample data";
    }
}
