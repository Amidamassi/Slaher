using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropItems : MonoBehaviour
{
    [SerializeField] public Dictionary<Item, float> dropList;

    private void OnDestroy()
    {if(dropList!=null)
     foreach(KeyValuePair <Item,float> keyValuePair in dropList)
            {
               if(keyValuePair.Value > Random.Range(0, 100))
                {
                    createDrop(keyValuePair.Key);
                }
            }
    }
    private void createDrop(Item item)
    {
        Instantiate(item.dropItem);
    }
}
