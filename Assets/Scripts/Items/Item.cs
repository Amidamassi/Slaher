using UnityEngine;
using System.Collections;
using System;
[Serializable]
public class Item 
{
    public int id { get; private set; }
    public Sprite inventorySprite;
    public float weight;
    public GameObject prefab;
    public string description;
}
