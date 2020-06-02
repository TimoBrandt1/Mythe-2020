using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float leftPushRange;
    [SerializeField] private float rightPushRange;
    [SerializeField] private Vector3 velocityThreshold;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity.z = velocityThreshold.z;
    }

    // Update is called once per frame
    void Update()
    {
        Push();
    }
    private void Push()
    {
        if (transform.rotation.z > 0
            && transform.rotation.z < rightPushRange
            && rb.angularVelocity > velocityThreshold)
        {
            rb.angularVelocity = velocityThreshold;
        }
        else if (true)
        {
            rb.angularVelocity = velocityThreshold * -1;
        }
    }
}
