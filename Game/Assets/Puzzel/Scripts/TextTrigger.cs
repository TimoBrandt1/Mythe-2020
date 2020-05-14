using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : PressurPlate
{
    [SerializeField] private float resetTiming = 10f;
    [SerializeField] private Timer actionOnTimer;
    [SerializeField] private TextTimer textTimer;
    [SerializeField] private string aInputText;
    [SerializeField] private bool canText = true;
    private void OnTriggerEnter(Collider other)
    {
        if (canText == true)
        {
            canText = false;
            textTimer.SetText(aInputText, resetTiming);
        }
    }
    private void OnTriggerExit(Collider other){}
}
