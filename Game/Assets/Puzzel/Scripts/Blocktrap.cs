using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocktrap : MonoBehaviour
{
    public GameObject InputEventTriggerObject;
    public GameObject OutputEventTriggerObject;
    private bool canMove = false;
    private Vector3 postionA;
    [SerializeField] private Vector3 targetPos;
    private Vector3 postionB;
    private Vector3 newPosition;
    [SerializeField]private float speed;
    [SerializeField]private float lerptime;
    [SerializeField]private float t;


    private void Start()
    {
        postionB = this.transform.position + targetPos;
        postionA = this.transform.position;
        lerptime = Random.Range(0.5f, 2f);
        //lerptime = 1;
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
        canMove = true;
    }
    private void OutputEventTrigger(object sender, System.EventArgs e)
    {
        canMove = false;
    }
    private void PositionChange()
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, lerptime*Time.deltaTime);
        t = Mathf.Lerp(t, 1f, lerptime * Time.deltaTime);
        if (t > 0.9f)
        {
            t = 0f;
            if (newPosition == postionB)
            {
                newPosition = postionA;
            }
            else if (newPosition == postionA)
            {
                newPosition = postionB;
            }
        }
    }


}
