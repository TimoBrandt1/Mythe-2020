using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    //The emty gameobject where the wall moves to
    [SerializeField] private Transform destination;

    //Floats were you can set the speed of the wall moving back and forward
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float backwardSpeed;

    private bool move = false;
    private Vector3 startPos;

    void Start()
    {
        //Sets the startposition of the wall
        startPos = transform.position;
    }

    void Update()
    {
        WallMove();
    }
    private void WallMove()
    {
        if (transform.position != startPos && move == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, backwardSpeed * Time.deltaTime);
            if (transform.position == startPos)
            {
                move = false;
            }
        }
        if(transform.position != destination.position && move == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination.position, forwardSpeed * Time.deltaTime);
            if (transform.position == destination.position)
            {
                move = true;
            }
        }
    }
}
