using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] Image inventory;
    private List<string> items;
    private bool inventoryOpen=true;
    void Update()
    {
        if (Input.GetKey("i"))
        {
            inventory.gameObject.SetActive(inventoryOpen);
        }
    }
    void OpenInventory()
    {
        items = Managers.Inventory.GetItemsList();

    }
}
