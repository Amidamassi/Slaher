using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Weapon:Item
    {
    float damageMin;
    float damageMax;
    float atackSpeed;
    }
public class RangeWeapon : Weapon
{
    public new ItemsType ItemType = ItemsType.rangeWeapon;
    float atackRange;
    GameObject bullet;
}
public class MeleeWeapon:Weapon
{
    public new ItemsType ItemType = ItemsType.meleeWeapon;
}
