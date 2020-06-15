using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
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


    private void Start()
    {
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
