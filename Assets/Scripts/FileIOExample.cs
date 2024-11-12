using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileIOExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.dataPath + "/Log.txt";

        // Write text to the file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("This is a log message.");
        writer.Close();

        Debug.Log("Text written to " + path);

        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);
            string content = reader.ReadToEnd();
            reader.Close();

            Debug.Log("File Content:\n" + content);
        }
        else
        {
            Debug.LogError("File not found at " + path);
        }
    }
}
