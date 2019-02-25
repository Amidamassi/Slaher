using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(EnemyList))]
public class EnemyListEditor : Editor
{
    private EnemyList enemyList;
    private int chosenEnemy;
    private void OnEnable()
    {
        enemyList = (EnemyList)target;
    }
    public override void OnInspectorGUI()
    {
        if (enemyList.enemies.Count != 0)
        {
            string[] enemyNames = new string[enemyList.enemies.Count];
            for(int i=0; i<enemyList.enemies.Count;i++)
            {
                enemyNames[i] = enemyList.enemies[i].enemyName;
            }
            chosenEnemy = EditorGUILayout.Popup(chosenEnemy, enemyNames);
            if (GUILayout.Button("Удалить моба"))
            {
                enemyList.enemies.Remove(enemyList.enemies[chosenEnemy]);
                chosenEnemy = 0;

            }
            enemyList.enemies[chosenEnemy].enemyName = EditorGUILayout.TextField("EnemyName",enemyList.enemies[chosenEnemy].enemyName);
            enemyList.enemies[chosenEnemy].enemyID = EditorGUILayout.IntField("EnemyID",enemyList.enemies[chosenEnemy].enemyID);
            enemyList.enemies[chosenEnemy].maxHP = EditorGUILayout.FloatField("Enemy maxHP",enemyList.enemies[chosenEnemy].maxHP);
            enemyList.enemies[chosenEnemy].xp = EditorGUILayout.FloatField("Enemy xp",enemyList.enemies[chosenEnemy].xp);
            enemyList.enemies[chosenEnemy].speed = EditorGUILayout.FloatField("Enemy speed",enemyList.enemies[chosenEnemy].speed);
            enemyList.enemies[chosenEnemy].atackDamage = EditorGUILayout.FloatField("Enemy atack damage",enemyList.enemies[chosenEnemy].atackDamage);
            enemyList.enemies[chosenEnemy].atackSpeed = EditorGUILayout.FloatField("Enemy atack speed",enemyList.enemies[chosenEnemy].atackSpeed);
                }
        if (GUILayout.Button("Добавить моба")) enemyList.enemies.Add(new BasicEnemy());
    }

}