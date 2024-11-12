using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public ItemData itemData;

    // Start is called before the first frame update
    void Start()
    {
        if (itemData != null)
        {
            Debug.Log("Item name: " + itemData.itemName);

        }
    }
}
