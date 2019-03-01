using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField] public EnemyList enemyList;
    [SerializeField] public BasicEnemy basicEnemy;
    private void OnDestroy()
    {
        Debug.Log("drop");
        Drop(basicEnemy.dropItems);
    }
    private void Update()
    {
        Debug.Log(basicEnemy.dropItems.Count);
    }
    private void RecieveDamage()
    {
        Destroy(gameObject);
    }
    public static void Drop(Dictionary<Item, float> drop)
    {
      

        foreach (KeyValuePair<Item, float> item in drop)
        {
            Debug.Log(item.Value);
            if (Random.Range(0, 100) <= item.Value)
            {
                Instantiate(item.Key.dropItem);
                Debug.Log("дропнулось");
            }
        }
    }

}
