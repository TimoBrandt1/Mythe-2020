using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStopTrigger : PressurPlate
{
    [SerializeField] private float timing = 3f;
    [SerializeField] private GameObject Deur;
    [SerializeField] private Timer actionOnTimer;
    [SerializeField] private TextTimer textTimer;
    private bool canMove = true;

    private void Start()
    {
        canMove = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (canMove == true)
        {
            canMove = false;
            textTimer.StartTimer(timing, "gehaald", Color.green);
            Deur.SetActive(true);
        }
    }

}
