using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BasicEnemy
{
    public int enemyID;
    public string enemyName="Name";
    public float xp;
    public float maxHP;
    public float atackDamage;
    public float speed;
    public float atackSpeed;
    public Dictionary<Item, float> dropItems = new Dictionary<Item, float>();
  
}
