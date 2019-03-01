using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(DropItemsList))]
public class DropItemsEditor : Editor
{
    private int chosenItem;
    private ItemsList itemsList ;
    private DropItemsList dropItems;
    private int chosenEnemy;
    private EnemyList enemyList;
    private int newItemInd;
    private float newItemChance;
    private void OnEnable()
    {
        
        dropItems = (DropItemsList)target;
        itemsList = dropItems.GetComponent<ItemsList>() as ItemsList;
        enemyList = dropItems.GetComponent<EnemyList>() as EnemyList;
  
    }
    public override void OnInspectorGUI()
    {
        if (enemyList.enemies.Count != 0)
        {
            string[] enemyNames = new string[enemyList.enemies.Count];
            for (int i = 0; i < enemyList.enemies.Count; i++)
            {
                enemyNames[i] = enemyList.enemies[i].enemyName;
            }
           
            chosenEnemy = EditorGUILayout.Popup(chosenEnemy, enemyNames);

            if (enemyList.enemies[chosenEnemy].dropItems.Count != 0)
            {
                string[] itemsName = new string[enemyList.enemies[chosenEnemy].dropItems.Count];
                int i = 0;
                Item[] items = new Item[enemyList.enemies[chosenEnemy].dropItems.Count];
                foreach (KeyValuePair<Item, float> keyValuePair in enemyList.enemies[chosenEnemy].dropItems)
                {
                    itemsName[i] = keyValuePair.Key.itemName;
                    items[i] = keyValuePair.Key;
                    i++;
                }
                chosenItem = EditorGUILayout.Popup(chosenItem, itemsName);
                enemyList.enemies[chosenEnemy].dropItems[items[chosenItem]] =
                    EditorGUILayout.FloatField("Процент выпадения",
                    enemyList.enemies[chosenEnemy].dropItems[items[chosenItem]]);
                if (GUILayout.Button("Удалить предмет"))
                {
                    enemyList.enemies[chosenEnemy].dropItems.Remove(items[chosenItem]);
                    chosenItem = 0;

                }
            }

            newItemChance = EditorGUILayout.FloatField("Процент выпадения предмета", newItemChance);
            string[] itemsListName = new string[itemsList.items.Count];

            for (int j = 0; j < itemsList.items.Count; j++)
            {
                itemsListName[j] = itemsList.items[j].itemName;
            }
            newItemInd = EditorGUILayout.Popup(newItemInd, itemsListName);
            if (GUILayout.Button("Добавить предмет"))
                enemyList.enemies[chosenEnemy].dropItems.Add(itemsList.items[newItemInd], newItemChance);
        }
        else
        {
            EditorGUILayout.LabelField("В базе нет врагов");
        }
        
    }
 
}