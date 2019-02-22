using UnityEngine;
using System.Collections;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private string ItemName;
    [SerializeField] GameObject obj;
    private void OnTriggerEnter(Collider other)
    {
        Managers.Inventory.AddItem(ItemName);
        Destroy(gameObject);
    }
}
