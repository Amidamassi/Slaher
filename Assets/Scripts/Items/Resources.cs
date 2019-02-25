using UnityEngine;
using System.Collections;

public class Resources :Item
{
    public new ItemsType ItemType = ItemsType.resource;
    public float amount;
}
public class Comsumable : Item
{
    public new ItemsType ItemType = ItemsType.consumable;
    public float amount;
}
