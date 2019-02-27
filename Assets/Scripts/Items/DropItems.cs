using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropItems : MonoBehaviour
{
    [SerializeField] public Dictionary<Item, float> dropList=new Dictionary<Item, float>();
    public static void Drop(DropItems drop)
    {
        foreach (KeyValuePair<Item, float> item in drop.dropList)
        {
            if (Random.Range(0, 100) <= item.Value)
            {
                Instantiate(item.Key.dropItem);
            }
        }
    }

}
