using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFreeController : MonoBehaviour
{
    /*PARAMS*/
    [Header("Objects")]
    public GameObject CameraFollowObj;
    public GameObject TargetObj;
    public GameObject CameraObj;

    [Header("Speed")]
    public float CameraMoveSpeed = 120f;
    public float inputSensitivity = 150f;
    public float idleAnimationInput = 0.3f;
    public float idleAnimationScroll = 0.1f;

    [Header("Angles")]
    [Range(0,180)]
    public float upperClampAngle = 80f;
    [Range(0, 180)]
    public float lowerClampAngle = 25f;

    [Header("Default angles")]
    public float Xrotation = 12.5f;
    public float Yrotation = 105.0f;

    [Space]
    public bool lockMode = false;
    public bool buttonPressed = false;
    public bool idleAnimation = false;
    [HideInInspector]
    public float scrollInput = 0.0f;

    private float _mouseX;
    private float _mouseY;
    private float _finalInputX;
    private float _finalInputZ;
    private float _rotY = 0.0f;
    private float _rotX = 0.0f;
    private CameraFreeLook _freeLookComponent = null;


    /*PRIVATE METHODS*/
    void Start()
    {
        transform.eulerAngles = new Vector3(Xrotation, Yrotation, 0.0f);
        Vector3 rot = transform.localRotation.eulerAngles;
        _rotY = rot.y;
        _rotX = rot.x;

        _freeLookComponent = CameraObj.GetComponent<CameraFreeLook>();
    }

    void Update()
    {
        MoveControll();
        IdleAnimation();
    }

    void LateUpdate()
    {
        CameraUpdate();
    }

    void MoveControll()
    {
        if (!lockMode)
        {
            if (buttonPressed)
            {
                _mouseX = Input.GetAxis("Mouse X");
                _mouseY = Input.GetAxis("Mouse Y");
                _finalInputX = _mouseX;
                _finalInputZ = -_mouseY;

                _rotY += _finalInputX * inputSensitivity * Time.deltaTime;
                _rotX += _finalInputZ * inputSensitivity * Time.deltaTime;

                _rotX = Mathf.Clamp(_rotX, -upperClampAngle, lowerClampAngle);
                Quaternion localRotation = Quaternion.Euler(_rotX, _rotY, 0.0f);
                transform.rotation = localRotation;
            }

            if (_freeLookComponent)
            {
                _freeLookComponent.Scrolling(scrollInput);
            }
        }
    }

    void IdleAnimation()
    {
        if (idleAnimation)
        {
            if(_rotX > 1)
            {
                _rotX -= idleAnimationInput * inputSensitivity * Time.deltaTime;
            }
            else if(_rotX < -1)
            {
                _rotX += idleAnimationInput * inputSensitivity * Time.deltaTime;
            }
            

            _rotY += idleAnimationInput * inputSensitivity * Time.deltaTime;
            Quaternion localRotation = Quaternion.Euler(_rotX, _rotY, 0.0f);
            transform.rotation = localRotation;

            _freeLookComponent.Scrolling(idleAnimationScroll);
        }
    }

    void CameraUpdate()
    {
        Transform target = CameraFollowObj.transform;

        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position + Vector3.down, step);
    }


    /*PUBLIC METHODS*/
    public void ResetSettings()
    {
        _rotX = Xrotation;
        _rotY = Yrotation;

        Quaternion localRotation = Quaternion.Euler(_rotX, _rotY, 0.0f);
        transform.rotation = localRotation;
    }
}
