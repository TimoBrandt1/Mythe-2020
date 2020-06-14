using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private GameObject _Backpack;
    [SerializeField] private Inventory _BackpackSlots;
    [SerializeField] private float _PickupDistance = 1f;
    [SerializeField] private Item _item;

    private void Start()
    {
        _BackpackSlots = _Backpack.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(_Backpack.transform.position, transform.position);
        if (dist < _PickupDistance && Input.GetKey(KeyCode.E) && _BackpackSlots.full == false)
        {
            _Backpack.GetComponent<Inventory>().AddItem(_item);
            this.gameObject.SetActive(false);
        }
    }
}
