using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : PressurPlate
{
    [SerializeField] private bool canSetText;
    [SerializeField] private UI_Assistant ui_Assistant;
    private void Start()
    {
        canSetText = true;
        ui_Assistant = GameObject.Find("UI_Assistant").GetComponent<UI_Assistant>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (canSetText)
        {
            ui_Assistant.Awake();
        }
    }
    private void OnTriggerExit(Collider other){ canSetText = false;}
}
