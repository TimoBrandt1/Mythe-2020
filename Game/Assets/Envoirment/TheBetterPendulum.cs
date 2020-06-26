using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBetterPendulum : MonoBehaviour
{
    private int SPEED;
    private bool isSpinning = false;
    [SerializeField] private bool canRotateFull = false;
    [SerializeField] private bool canMove = false;
    public GameObject InputEventTriggerObject;
    public GameObject OutputEventTriggerObject;
    private Rigidbody rb;
    [SerializeField] private float leftPushRange;
    [SerializeField] private float rightPushRange;
    [SerializeField] private Vector3 velocityThreshold;
    private HingeJoint myJoint;
    private JointMotor myMotor;
    // Start is called before the first frame update
    void Start()
    {
        myJoint = GetComponent<HingeJoint>();

        // Make the hinge motor rotate with 90 degrees per second and a strong force.
         myMotor = myJoint.motor;

        EventTrigger inputEventTrigger = InputEventTriggerObject.GetComponent<EventTrigger>();
        inputEventTrigger.OnEventEnter += InputEventTrigger;

        EventTrigger outputEventTrigger = OutputEventTriggerObject.GetComponent<EventTrigger>();
        outputEventTrigger.OnEventEnter += OutputEventTrigger;
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = velocityThreshold;
        //Debug.Log(rb.angularVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        myJoint.motor = myMotor;
        if (canMove == true)
        {
            Push();

        }
    }
    private void Push()
    {
        if (canRotateFull == false)
        {
            if (transform.rotation.z > 0
                && transform.rotation.z < rightPushRange
                && (rb.angularVelocity.z > 0)
                && rb.angularVelocity.z < velocityThreshold.z)
            {
                rb.angularVelocity = velocityThreshold;
            }
            else if (transform.rotation.z < 0
                && transform.rotation.z > rightPushRange
                && (rb.angularVelocity.z < 0)
                && rb.angularVelocity.z > velocityThreshold.z * -1)
            {
                rb.angularVelocity = velocityThreshold * -1;
            }
        }
    }
    private void InputEventTrigger(object sender, System.EventArgs e)
    {
        if (isSpinning == false)
        {
            if (canRotateFull)
            {
                SPEED = Random.Range(300, 800);
                myMotor.targetVelocity = SPEED;
                myJoint.motor = myMotor;
            }
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            canMove = true;
        }
    }
    private void OutputEventTrigger(object sender, System.EventArgs e)
    {
        if (isSpinning == true)
        {
            if (canRotateFull)
            {
                myMotor.targetVelocity = SPEED - SPEED;

            }
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            canMove = false;
        }
    }
}
