using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : PressurPlate
{
    [SerializeField] private GameObject Deur;
    [SerializeField] private Timer actionOnTimer;
    [SerializeField] private TextTimer textTimer;

    private void OnTriggerExit(Collider other)
    {
        textTimer.StartTimer();
        Deur.SetActive(true);
    }
}
