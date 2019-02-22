using UnityEngine;
using System.Collections;
using System;
[Serializable]
public class Item 
{
    public string itemName;
    public virtual ItemsType ItemType { get; set; }
    public int id { get; private set; }
    public Sprite inventorySprite;
    public float weight;
    public string description;
    public GameObject dropItem;
}
