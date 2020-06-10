using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item[] itemArray = new Item[3];
    public bool full = false;

    public bool AddItem(Item item)
    {
        for(int i = 1; i < itemArray.Length; i++)
        {
            Debug.Log(itemArray[i]);
            if (itemArray[i] == null)
            {
                itemArray[i] = item;
                full = false;
                return true;
            }
        }
        full = true;
        return false;
    }
}
