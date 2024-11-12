using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DataDownloader : MonoBehaviour
{
    public Text statusText;
    // Start is called before the first frame update
    async void Start()
    {
        string data = await DownloadDataAsync();
        StartCoroutine(UpdateUI(data));
    }

    async Task<string> DownloadDataAsync()
    {
        await Task.Delay(2000);
        return "Downloaded Data";
    }

    IEnumerator UpdateUI(string data)
    {
        statusText.text = "Processing data...";
        yield return new WaitForSeconds(1f);
        statusText.text = "Data: " + data;
    }
}
