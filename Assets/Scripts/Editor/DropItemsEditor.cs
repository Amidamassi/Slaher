using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(DropItems))]
public class DropItemsEditor : Editor
{
    private int chosenItem;
    private ItemsList itemsList ;
    private DropItems dropItems;
    private int newItemInd;
    private float newItemChance;
    private void OnEnable()
    {
        
        dropItems = (DropItems)target;
        itemsList = dropItems.GetComponent<ItemsList>() as ItemsList;
    }
    public override void OnInspectorGUI()
    {

        if (dropItems.dropList.Count != 0)
        {
            string[] itemsName = new string[dropItems.dropList.Count];
            int i = 0;
            Item[] items = new Item[dropItems.dropList.Count];
            foreach (KeyValuePair<Item, float> keyValuePair in dropItems.dropList)
            {
                itemsName[i] = keyValuePair.Key.itemName;
                items[i] = keyValuePair.Key;
                i++;
            }
            chosenItem = EditorGUILayout.Popup(chosenItem, itemsName);
            dropItems.dropList[items[chosenItem]] = EditorGUILayout.FloatField("Процент выпадения", dropItems.dropList[items[chosenItem]]);
            if (GUILayout.Button("Удалить предмет"))
            {
                dropItems.dropList.Remove(items[chosenItem]);
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
            if (GUILayout.Button("Добавить предмет")) dropItems.dropList.Add(itemsList.items[newItemInd], newItemChance);
        
    }
}