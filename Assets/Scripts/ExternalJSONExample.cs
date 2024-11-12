using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ExternalJSONExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Create a dictionary to serialize
        Dictionary<string, int> playerStats = new Dictionary<string, int>
        {
            { "level", 5 },
            { "experience", 1500 },
            { "health", 100 }
        };

        // Serialize the dictionary to JSON
        string json = JsonConvert.SerializeObject(playerStats, Formatting.Indented);
        Debug.Log("Serialized JSON:\n" + json);

        // Deserialize the JSON back to a dictionary
        Dictionary<string, int> deserializedStats = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
        Debug.Log("Deserialized Data:");
        foreach (var stat in deserializedStats)
        {
            Debug.Log(stat.Key + ": " + stat.Value);
        }
    }
}
