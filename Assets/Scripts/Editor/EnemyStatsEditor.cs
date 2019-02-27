using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(EnemyStats))]
    class EnemyStatsEditor: Editor
    {
    private EnemyStats enemyStats;
    private EnemyList enemyList;
    private int chosenEnemy;
    private void OnEnable()
    {
        enemyStats = (EnemyStats)target;
    }
    public override void OnInspectorGUI()
    {
        enemyList =(EnemyList)EditorGUILayout.ObjectField("Список противников",enemyList, typeof( EnemyList),false);
        if (enemyList.enemies.Count != 0)
            {
                string[] enemyNames = new string[enemyList.enemies.Count];
                for (int i = 0; i < enemyList.enemies.Count; i++)
                {
                    enemyNames[i] = enemyList.enemies[i].enemyName;
                }
                chosenEnemy = EditorGUILayout.Popup(chosenEnemy, enemyNames);
            }
        if (GUILayout.Button("Выбрать моба")) enemyStats.basicEnemy = enemyList.enemies[chosenEnemy];
    }
    }
