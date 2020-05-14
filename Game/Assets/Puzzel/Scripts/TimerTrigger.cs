using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : PressurPlate
{
    [SerializeField] private float timing =5f;
    [SerializeField] private Rigidbody Deur;
    [SerializeField] private Timer actionOnTimer;
    [SerializeField] private TextTimer textTimer;
    private bool canMove = true;

    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other){}

    private void OnTriggerExit(Collider other)
    {
        if (canMove == true)
        {
            canMove = false;
            textTimer.StartTimer(timing,"je hebt gefaald",Color.red);
            Deur.useGravity = true;
        }
    }
}
