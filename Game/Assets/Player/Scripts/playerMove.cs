using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField] private float _movingTurnSpeed = 360;
    [SerializeField] private float _stationaryTurnSpeed = 180;
    [SerializeField] private float _moveSpeedMultiplier = 1f;
    [SerializeField] private float _groundCheckDistance = 0.1f;

    private Rigidbody _rigidbody;
    private float _origGroundCheckDistance;
    private float _turnAmount;
    private float _forwardAmount;
    private Vector3 _groundNormal;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        _origGroundCheckDistance = _groundCheckDistance;
    }

    public void Move(Vector3 move, bool jump)
    {
        Vector3 vel = (move * _moveSpeedMultiplier) / Time.deltaTime;

        //zet de rigidbody content gelijk aan de vel vector
        vel.y = _rigidbody.velocity.y;
        _rigidbody.velocity = vel;
 
        if (move.magnitude > 1f) move.Normalize();
        move = transform.InverseTransformDirection(move);
        CheckGroundStatus();
        move = Vector3.ProjectOnPlane(move, _groundNormal);
        _turnAmount = Mathf.Atan2(move.x, move.z);
        _forwardAmount = move.z;

        ApplyExtraTurnRotation();
    }

    void CheckGroundStatus()
    {
        RaycastHit hitInfo;
        // laat de lijn zien voor debug purposes
        Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * _groundCheckDistance));

        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, _groundCheckDistance))
        {
            _groundNormal = hitInfo.normal;
        }
        else
        {
            _groundNormal = Vector3.up;
        }
    }

    void ApplyExtraTurnRotation()
    {
        // laat het caracter sneller draaien
        float turnSpeed = Mathf.Lerp(_stationaryTurnSpeed, _movingTurnSpeed, _forwardAmount);
        transform.Rotate(0, _turnAmount * turnSpeed * Time.deltaTime, 0);
    }

}
