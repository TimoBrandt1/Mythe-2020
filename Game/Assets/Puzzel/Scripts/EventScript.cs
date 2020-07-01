using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    public event EventHandler OnEventEnter;
    private void OnTriggerEnter(Collider other)
    {
        OnEventEnter?.Invoke(this, EventArgs.Empty);
    }
    

}
