using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour,IGameManager
{
    public ManagerStatus status { get; private set; }
    private Dictionary<string,int> items;

    public void Startup()
    {
        items = new Dictionary<string, int>();
        status = ManagerStatus.Started;
    }
    private void DisplayItems()
    {
        foreach(KeyValuePair<string,int> item in items)
        {

        }
    }
    public void AddItem(string newItem)
    {
        if (items.ContainsKey(newItem))
        {
            items[newItem] += 1;
        }
        else
        {
            items[newItem] = 1;
        }
    }
    public List<string> GetItemsList()
    {
        List<string> list = new List<string>(items.Keys);
        return list;
    }
    public int GetItemCount(string item)
    {
        if (items.ContainsKey(item))
            return items[item];
        return 0;
    }


}
