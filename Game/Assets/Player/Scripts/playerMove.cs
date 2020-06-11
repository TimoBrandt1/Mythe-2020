using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField] private float _movingTurnSpeed = 360;
    [SerializeField] private float _stationaryTurnSpeed = 180;
    [SerializeField] private float _moveSpeedMultiplier = 1f;
    [SerializeField] private float _groundCheckDistance = 0.1f;

    private PlayerClimb _PlayerClimb;

    private Animator _anim;
    private Rigidbody _rigidbody;
    private float _origGroundCheckDistance;
    private float _turnAmount;
    public float _maxForwardAmount;
    public float _forwardAmount;
    private Vector3 _groundNormal;
    private Vector3 moveCurrent;
    bool m_IsGrounded;

    void Start()
    {
        _maxForwardAmount = 1f;
        _rigidbody = GetComponent<Rigidbody>();
        _anim = GetComponentInChildren<Animator>();
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        _origGroundCheckDistance = _groundCheckDistance;

        _PlayerClimb = GetComponent<PlayerClimb>();
        _PlayerClimb.onPlayerClimb += onPlayerClimbActive;
        _PlayerClimb.onPlayerLoose += onPlayerLooseActive;
    }

    public void Move(Vector3 move, bool jump)
    {
        Vector3 vel = (move * _moveSpeedMultiplier) / Time.deltaTime;

        //zet de rigidbody content gelijk aan de vel vector
        vel.y = _rigidbody.velocity.y;
        _rigidbody.velocity = vel;

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, 14f);
        }
        else
        {
            _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, 20f);
        }

        move = transform.InverseTransformDirection(move);
        CheckGroundStatus();
        move = Vector3.ProjectOnPlane(move, _groundNormal);
        _turnAmount = Mathf.Atan2(move.x, move.z);

        if (move.z > 0)
        {
            _forwardAmount += move.z / 20;
        }
        else
        {
            if(_forwardAmount > 0) _forwardAmount -= 0.1f;

        }

        if (!m_IsGrounded)
        {
            HandleAirborneMovement();
        }

        moveCurrent.z = move.z;
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
            m_IsGrounded = true;
            //_rigidbody.useGravity = true;
        }
        else
        {
            _groundNormal = Vector3.up;
            m_IsGrounded = false;
            //_rigidbody.useGravity = false;
        }
    }

    void ApplyExtraTurnRotation()
    {
        // laat het caracter sneller draaien
        float turnSpeed = Mathf.Lerp(_stationaryTurnSpeed, _movingTurnSpeed, _forwardAmount);
        transform.Rotate(0, _turnAmount * turnSpeed *  Time.deltaTime, 0);
        _anim.SetFloat("Turn", _turnAmount, 0.1f, Time.deltaTime);
    }

    public float GetVelocity()
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (_maxForwardAmount > 0.5f) _maxForwardAmount -= 1f * Time.deltaTime;

            if (_forwardAmount <= 0.5f) _maxForwardAmount = 0.5f;

            if (_forwardAmount > _maxForwardAmount) _forwardAmount = _maxForwardAmount;

        }else if (moveCurrent.z > 1f)
        {
            if (_maxForwardAmount > 1.5f) _maxForwardAmount = 1.5f;
            else _maxForwardAmount += 1f * Time.deltaTime; 
            _forwardAmount = _maxForwardAmount;
        }
        return _forwardAmount;
    }

    void HandleAirborneMovement()
    {
        _groundCheckDistance = _rigidbody.velocity.y < 0 ? _origGroundCheckDistance : 0.01f;
    }

    void onPlayerClimbActive()
    {
        _rigidbody.useGravity = false;
    }

    void onPlayerLooseActive()
    {
        _rigidbody.useGravity = true;
    }
}
