using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Item[] _itemArray = new Item[3];
    public bool full = false;

    public bool AddItem(Item item)
    {
        for(int i = 1; i < _itemArray.Length; i++)
        {
            Debug.Log(_itemArray[i]);
            if (_itemArray[i] == null)
            {
                _itemArray[i] = item;
                full = false;
                return true;
            }
        }
        full = true;
        return false;
    }
}
