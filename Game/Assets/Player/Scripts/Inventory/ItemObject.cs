using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private GameObject Backpack;
    [SerializeField] private Inventory BackpackSlots;
    [SerializeField] private float PickupDistance = 1f;
    [SerializeField] private Item item;

    private void Start()
    {
        BackpackSlots = Backpack.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Backpack.transform.position, transform.position);
        if (dist < PickupDistance && Input.GetKey(KeyCode.E) && BackpackSlots.full == false)
        {
            Backpack.GetComponent<Inventory>().AddItem(item);
            this.gameObject.SetActive(false);
        }
    }
}
