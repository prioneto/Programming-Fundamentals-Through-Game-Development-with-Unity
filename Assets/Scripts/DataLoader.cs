using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataLoader : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(FetchDataCoroutine());
    }

    IEnumerator FetchDataCoroutine()
    {
        Debug.Log("Fetching data from server...");
        UnityWebRequest request = UnityWebRequest.Get("https://api.example.com/data");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error fetching data: " + request.error);
        }
        else
        {
            Debug.Log("Data received: " + request.downloadHandler.text);
        }
    }
}
