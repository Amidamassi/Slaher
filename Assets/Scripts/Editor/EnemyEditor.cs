using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    private Enemy enemy;
    private int chosenEnemy;
    private void OnEnable()
    {
        enemy = (Enemy)target;
    }
    public override void OnInspectorGUI()
    {
        enemy.enemyList = (EnemyList)EditorGUILayout.ObjectField(enemy.enemyList, typeof(EnemyList),true);
        if (enemy.enemyList != null)
        {
            string[] enemyNames = new string[enemy.enemyList.enemies.Count];
            for (int i = 0; i < enemy.enemyList.enemies.Count; i++)
            {
                enemyNames[i] = enemy.enemyList.enemies[i].enemyName;
            }
            chosenEnemy = EditorGUILayout.Popup(chosenEnemy, enemyNames);
            Debug.Log(chosenEnemy);
            enemy.basicEnemy = enemy.enemyList.enemies[chosenEnemy];
        }
    }
}
