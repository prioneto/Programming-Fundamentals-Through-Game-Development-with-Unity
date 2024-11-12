using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    private Dictionary<string, int> inventory = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        inventory.Add("Health Potion", 2);
        inventory.Add("Sword", 1);
        inventory.Add("Shield", 3);
        inventory.Add("Potion", 2);
        inventory.Add("Gun", 1);
        inventory.Add("Machete", 3);

        /*var sortedInventory = inventory.OrderBy(item => item.Value).ToList();*/
        var groupedItems = from item in inventory
                           group item by item.Value into itemGroup
                           select itemGroup;

        foreach (var group in groupedItems)
        {
            Debug.Log("Item Type: " + group.Key);
            foreach (var item in group)
            {
                Debug.Log(" - " + item.Key);
            }
        }

        /*Debug.Log("Sorted Inventory by Rarity:");
        foreach (var item in sortedInventory)
        {
            Debug.Log(item.Key + " - Rarity: " + item.Value);
        }*/

        /*string itemToFind = "Sword";
        if (inventory.Contains(itemToFind))
        {
            Debug.Log(itemToFind + " is in the inventory");
        }
        else
        {
            Debug.Log(itemToFind + " not found");
        }*/

    }
}
