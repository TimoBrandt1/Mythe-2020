using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraControl : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1;
    [SerializeField] private float _turnSmoothing;
    [SerializeField] private Transform _Target, _Player;

    float mouseX, mouseY;
    public Transform Obstruction;
    Quaternion targetRotation;

    void Start()
    {
        Obstruction = _Target;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * _rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * _rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(_Target);

        _Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);

    }
}