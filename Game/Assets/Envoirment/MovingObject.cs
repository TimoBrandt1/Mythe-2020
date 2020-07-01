using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private bool isSpike;
    [SerializeField] private AudioSource myAudio;
    [SerializeField] private float randomMax;
    [SerializeField] private float randommin;
    public GameObject InputEventTriggerObject;
    public GameObject OutputEventTriggerObject;
    private bool canMove = false;
    private Vector3 postionA;
    [SerializeField] private Vector3 targetPos;
     private Vector3 destination;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float backwardSpeed;
    private bool move = false;
    private Vector3 startPos;
    private string nameScript;

    private void Start()
    {
        if (isSpike)
        {
            forwardSpeed = Random.Range(randommin, randomMax);
            backwardSpeed = Random.Range(randommin/5, randomMax/5);
        }
        startPos = transform.position;
        destination = transform.position + targetPos;
        EventTrigger inputEventTrigger = InputEventTriggerObject.GetComponent<EventTrigger>();
        inputEventTrigger.OnEventEnter += InputEventTrigger;

        EventTrigger outputEventTrigger = OutputEventTriggerObject.GetComponent<EventTrigger>();
        outputEventTrigger.OnEventEnter += OutputEventTrigger;
    }
    private void Update()
    {
        if (canMove == true)
        {
            WallMove();
        }
    }
    private void WallMove()
    {
        if (transform.position != startPos && move == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, backwardSpeed);
            if (transform.position == startPos)
            {
                myAudio.Play();
                move = false;
            }
        }
        if (transform.position != destination && move == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, forwardSpeed);
            if (transform.position == destination)
            {
                
                move = true;
            }
        }
    }
    private void InputEventTrigger(object sender, System.EventArgs e)
    {
        canMove = true;
    }
    private void OutputEventTrigger(object sender, System.EventArgs e)
    {
        canMove = false;
    }
}
