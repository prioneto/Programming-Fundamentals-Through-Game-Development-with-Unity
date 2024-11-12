using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Enemy enemy = (Enemy)target;

        EditorGUILayout.LabelField("Enemy Settings", EditorStyles.boldLabel);

        enemy.stats.enemyName = EditorGUILayout.TextField("Name", enemy.stats.enemyName);
        enemy.stats.health = EditorGUILayout.IntField("Health", enemy.stats.health);
        enemy.stats.damage = EditorGUILayout.IntField("Damage", enemy.stats.damage);
        enemy.stats.speed = EditorGUILayout.FloatField("Speed", enemy.stats.speed);

        if (GUILayout.Button("Reset Stats"))
        {
            enemy.stats.health = 100;
            enemy.stats.damage = 10;
            enemy.stats.speed = 2.0f;
        }

        // Ensure changes are saved
        if (GUI.changed)
        {
            EditorUtility.SetDirty(enemy);
        }
    }
}
