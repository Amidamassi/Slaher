using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy
{
    public int enemyID;
    public string enemyName;
    public float xp;
    public float maxHP;
    public float atackDamage;
    public float speed;
    public float atackSpeed;
    public DropItems dropItems = new DropItems();
    public BasicEnemy()
    {
        enemyName = "Name";

    }
}
