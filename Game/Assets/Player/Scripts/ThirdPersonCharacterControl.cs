using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterControl : MonoBehaviour
{
    private playerMove _player; 
    private Transform _mainCam;            
    private Vector3 _camForward;          
    private Vector3 _move;
    private bool _jump;                

    private void Start()
    {
        if (Camera.main != null)
        {
            _mainCam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject); 
        }

        _player = GetComponent<playerMove>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (_mainCam != null)
        {
            // calculate camera relative direction to move:
            _camForward = Vector3.Scale(_mainCam.forward, new Vector3(1, 0, 1)).normalized;
            _move = vertical * _camForward + horizontal * _mainCam.right;
        }

        _player.Move(_move, _jump);
        _jump = false;
    }
}