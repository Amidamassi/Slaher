using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(DropItems))]
public class DropItemsEditor : Editor
{
    private int chosenItem;
    
    private DropItems dropItems;
    private int newItemInd;
    private float newItemChance;
    private void OnEnable()
    {
        dropItems = (DropItems)target;
    }
    public override void OnInspectorGUI()
    {
        if (dropItems.dropList != null)
        {
            string[] itemsName = new string[dropItems.dropList.Count];
            int i = 0;
            Item[] items = new Item[dropItems.dropList.Count];
            foreach (KeyValuePair<Item, float> keyValuePair in dropItems.dropList)
            {
                itemsName[i] = keyValuePair.Key.itemName;
                items[i] = keyValuePair.Key;
                Debug.Log("wtf");
            }
            chosenItem = EditorGUILayout.Popup(chosenItem, itemsName);
            dropItems.dropList[items[chosenItem]] = EditorGUILayout.FloatField("Процент выпадения", dropItems.dropList[items[chosenItem]]);
        }
       if (GUILayout.Button("Добавить предмет")) dropItems.dropList.Add(Managers.itemlist.items[newItemInd], newItemChance);
        newItemChance= EditorGUILayout.FloatField("Процент выпадения предмета", newItemChance);
         string[] itemsListName = new string[Managers.itemlist.items.Count];
       
        for (int j = 0; j < Managers.itemlist.items.Count; j++)
       {
          itemsListName[j] = Managers.itemlist.items[j].itemName;
        }
        newItemInd = EditorGUILayout.Popup(newItemInd, itemsListName);
    }
}