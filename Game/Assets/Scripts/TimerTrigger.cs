using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : PressurPlate
{
    [SerializeField] private float timing =5f;
    [SerializeField] private GameObject Deur;
    [SerializeField] private Timer actionOnTimer;
    [SerializeField] private TextTimer textTimer;

    private void OnTriggerExit(Collider other)
    {
        if (canMove == true)
        {
            canMove = false;
            textTimer.StartTimer(timing,"je hebt gefaald",Color.red);
            Deur.SetActive(true);
        }
    }
}
