using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textRotate : MonoBehaviour
{
    [SerializeField] private Transform targetobject;
    [SerializeField] private float damping;

    // Update is called once per frame
    void Update()
    {
        var lookPos = targetobject.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
}
