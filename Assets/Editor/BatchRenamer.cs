using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BatchRenamer : EditorWindow
{
    string baseName = "GameObject";
    int startIndex = 0;

    [MenuItem("Window/Batch Renamer")]
    public static void ShowWindow()
    {
        GetWindow<BatchRenamer>("Batch Renamer");
    }

    void OnGUI()
    {
        GUILayout.Label("Batch Rename Selected GameObjects", EditorStyles.boldLabel);

        baseName = EditorGUILayout.TextField("Base Name", baseName);
        startIndex = EditorGUILayout.IntField("Start Index", startIndex);

        if (GUILayout.Button("Rename"))
        {
            RenameGameObjects();
        }
    }

    void RenameGameObjects()
    {
        GameObject[] selectedObjects = Selection.gameObjects;
        for (int i = 0; i < selectedObjects.Length; i++)
        {
            selectedObjects[i].name = baseName + "_" + (startIndex + i);
        }
        Debug.Log("Renamed " + selectedObjects.Length + " GameObjects.");
    }
}
