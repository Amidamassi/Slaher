using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour,IRecieveDamage
{
    public void RecieveDamage(float damage)
    {
        Destroy(gameObject);
    }
}
