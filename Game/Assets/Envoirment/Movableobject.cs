using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movableobject : MonoBehaviour
{
    [SerializeField] bool hasAudio;
    private AudioSource thisAudioSource;
    private AudioClip thisAudioClip;
    public GameObject InputEventTriggerObject;
    public GameObject OutputEventTriggerObject;
    private bool canMove = false;
    private Vector3 postionA;
    [SerializeField] private Vector3 targetPos;
    private Vector3 postionB;
    private Vector3 newPosition;
    [SerializeField] private float lerpspeed;
    [SerializeField] private float t;


    private void Start()
    {
        if (hasAudio)
        {
            thisAudioSource = gameObject.GetComponent<AudioSource>();
            thisAudioClip = thisAudioSource.clip;
            lerpspeed = 1 / (thisAudioClip.length * 0.5f);
        }
        else
        {
            lerpspeed = 5;
        }
        postionB = this.transform.position + targetPos;
        postionA = this.transform.position;
        EventTrigger inputEventTrigger = InputEventTriggerObject.GetComponent<EventTrigger>();
        inputEventTrigger.OnEventEnter += InputEventTrigger;

        EventTrigger outputEventTrigger = OutputEventTriggerObject.GetComponent<EventTrigger>();
        outputEventTrigger.OnEventEnter += OutputEventTrigger;
    }
    private void Update()
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
    private void InputEventTrigger(object sender, System.EventArgs e)
    {
        if (transform.position == postionA)
        {
            if (thisAudioClip != null)
            {
                thisAudioSource.Play();
            }
            canMove = true;
        }
    }
    private void OutputEventTrigger(object sender, System.EventArgs e)
    {
        if (transform.position == postionB)
        {
            if (thisAudioClip != null)
            {
                thisAudioSource.Play();
            }
            canMove = true;
        }
    }
    private void PositionChange()
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, lerpspeed * Time.deltaTime);
        t = Mathf.Lerp(t, 1f, lerpspeed * Time.deltaTime);
        if (t > 0.95f)
        {
            t = 0f;
            if (newPosition == postionB)
            {
                transform.position = postionB;
                
                newPosition = postionA;
                canMove = false;
            }
            else if (newPosition == postionA)
            {
                transform.position = postionA;
                newPosition = postionB;
                canMove = false;
            }
        }
    }


}
