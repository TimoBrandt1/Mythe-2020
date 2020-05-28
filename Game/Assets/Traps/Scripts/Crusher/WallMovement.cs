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

    private Vector3 startPos;
    private bool touched = false;

    void Start()
    {
        //Sets the startposition of the wall
        startPos = transform.position;
    }

    void Update()
    {
        WallMove();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CrushWall")
        {
            touched = true;
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(50);
        }
    }
    private void WallMove()
    {
        if (touched == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination.position, forwardSpeed);
        }
        if (touched == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, backwardSpeed);
            if (transform.position == startPos)
            {
                touched = false;
            }
        }
    }
}
