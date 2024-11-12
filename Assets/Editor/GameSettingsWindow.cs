using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameSettingsWindow : EditorWindow
{
    string gameTitle = "My Awesome Game";
    int maxPlayers = 4;
    float gameVolume = 1.0f;

    [MenuItem("Window/Game Settings")]
    public static void ShowWindow()
    {
        GetWindow<GameSettingsWindow>("Game Settings");
    }

    void OnGUI()
    {
        GUILayout.Label("Game Settings", EditorStyles.boldLabel);

        gameTitle = EditorGUILayout.TextField("Game Title", gameTitle);
        maxPlayers = EditorGUILayout.IntSlider("Max Players", maxPlayers, 1, 16);
        gameVolume = EditorGUILayout.Slider("Game Volume", gameVolume, 0f, 1f);

        if (GUILayout.Button("Save Settings"))
        {
            SaveSettings();
        }
    }

    void SaveSettings()
    {
        // Implement saving logic here
        Debug.Log("Game settings saved.");
    }
}
