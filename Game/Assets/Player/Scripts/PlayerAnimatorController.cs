using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private playerMove _playerMove;
    private Animator _anim;
    private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        _playerMove = GetComponent<playerMove>();
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _speed = _playerMove.GetVelocity();
        //Debug.Log(_speed);
        _anim.SetFloat("Forward", _speed, 0.1f, Time.deltaTime);

    }
}
