using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLisener : MonoBehaviour
{
    public GameObject InputEventTriggerObject;
    public GameObject OutputEventTriggerObject;

    private void Start()
    {
        EventTrigger inputEventTrigger = InputEventTriggerObject.GetComponent<EventTrigger>();
        inputEventTrigger.OnEventEnter += InputEventTrigger_OnSpacePressed;

        EventTrigger outputEventTrigger = OutputEventTriggerObject.GetComponent<EventTrigger>();
        outputEventTrigger.OnEventEnter += OutputEventTrigger_OnSpacePressed;
    }
    private void InputEventTrigger_OnSpacePressed(object sender, System.EventArgs e)
    {
        this.gameObject.SetActive(true);
    }
    private void OutputEventTrigger_OnSpacePressed(object sender, System.EventArgs e)
    {
        this.gameObject.SetActive(false);
    }
}
