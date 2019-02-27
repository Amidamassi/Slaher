using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    public BasicEnemy basicEnemy = new BasicEnemy();
    private void OnDestroy()
    {
        DropItems.Drop(basicEnemy.dropItems);
    }
}
