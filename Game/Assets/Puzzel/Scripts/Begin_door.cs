using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin_door : MonoBehaviour
{
    [SerializeField]private float currentTime;
    [SerializeField]private float WaitTime = 5;

    private AudioSource doorAudio;
    private AudioClip doorClip;
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
        doorAudio = gameObject.GetComponent<AudioSource>();
        doorClip = doorAudio.clip;
        postionB = this.transform.position + targetPos;
        postionA = this.transform.position;
        lerpspeed = 1 / doorClip.length;
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= WaitTime)
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
                    doorAudio.Play();
                    newPosition = postionB; 
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
            if (newPosition == postionA)
            {
                newPosition = postionB;
                canMove = false;
            }
        }
    }


}
