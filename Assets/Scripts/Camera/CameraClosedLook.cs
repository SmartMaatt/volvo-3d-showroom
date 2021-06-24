using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraClosedLook : MonoBehaviour
{
    /*PARAMS*/
    [Header("Sensitivity")]
    public float sensitivityHor = 6.0f;
    public float sensitivityVer = 6.0f;

    [Header("Vertical limits")]
    [Range(0,180)]
    public float minVer = 60.0f;
    [Range(0, 180)]
    public float maxVer = 60.0f;

    [Header("Horizontal limits")]
    [Range(0, 360)]
    public float minHor = 0.0f;
    [Range(0, 360)]
    public float maxHor = 270.0f;

    [Header("Scroll")]
    public float minScroll = 30f;
    public float maxScroll = 60f;
    public float scrollIntesivity = 1f;

    private bool _lockMode = false;
    private bool _buttonPressed = false;
    private float _rotationX = 0.0f;
    private Camera _cameraComponent = null;


    /*PRIVATE METHODS*/
    void Awake()
    {
        _cameraComponent = GetComponent<Camera>();
        _cameraComponent.fieldOfView = maxScroll;
    }

    void Update()
    {
        if (!_lockMode && _buttonPressed)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, -minVer, maxVer);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            rotationY = Mathf.Clamp(rotationY, -minHor, maxHor);

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }


    /*PUBLIC METHODS*/
    public void SetLockMode(bool lockMode)
    {
        _lockMode = lockMode;
    }

    public void SetButtonPressed(bool buttonPressed)
    {
        _buttonPressed = buttonPressed;
    }

    public void ResetFieldOfView()
    {
        if(_cameraComponent)
            _cameraComponent.fieldOfView = maxScroll;
    }

    public void Scrolling(float mouseScroll)
    {
        if (!_lockMode)
        {
            _cameraComponent.fieldOfView += mouseScroll * scrollIntesivity;
            _cameraComponent.fieldOfView = Mathf.Clamp(_cameraComponent.fieldOfView, minScroll, maxScroll);
        }
    }

    public void SetDistance(float distance)
    {
        _cameraComponent.fieldOfView = Mathf.Clamp(distance, minScroll, maxScroll);
    }
}
