using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin_door : MonoBehaviour
{
    [SerializeField]private float currentTime;
    [SerializeField]private float targetTime = 5;

    private bool canMove = false;
    private bool start = false;
    private Vector3 postionA;
    [SerializeField] private Vector3 targetPos;
    private Vector3 postionB;
    private Vector3 newPosition;
    [SerializeField] private float lerpspeed;
    [SerializeField] private float t;


    private void Start()
    {
        postionB = this.transform.position + targetPos;
        postionA = this.transform.position;
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= targetTime)
        {
            start = true;
            canMove = true;
        }
        if (start == true)
        {
            if (canMove == true)
            {
                if (transform.position == postionA)
                {
                    newPosition = postionB;
                    
                }
                if (transform.position == postionB)
                {
                    newPosition = postionA;
                }
                PositionChange();
            }
        }
    }

    private void PositionChange()
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, lerpspeed * Time.deltaTime);
        t = Mathf.Lerp(t, 1f, lerpspeed * Time.deltaTime);
        if (t > 0.95f)
        {
            canMove = false;
            t = 0f;
            if (newPosition == postionB)
            {
                newPosition = postionA;
                canMove = false;
            }
            else if (newPosition == postionA)
            {
                newPosition = postionB;
                canMove = false;
            }
        }
    }


}
