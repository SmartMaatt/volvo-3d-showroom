using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    /*PARAMS*/
    [Header("References")]
    [SerializeField] private CameraFreeController cameraFreeController;
    [SerializeField] private CameraClosedController cameraClosedController;
    [Space]
    public bool moveLock = false;
    public bool lmbPressed = false;
    public bool freeCamera = true;
    public bool resetSettings = false;
    public bool idleAnimation = false;
    [Space]
    public float idleTime = 0.0f;
    public float maxIdleTime = 60.0f;


    /*PRIVATE METHODS*/
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        EscapeTrigger();
        LeftMouseButtonTrigger();

        FreeCloseTrigger();
        ChangeSeatTrigger();

        IdleAnimationTrigger();
    }

    void LateUpdate()
    {
        EscapeChange();
        LeftMouseButtonChange();
        ScrollInput();

        IdleAnimation();
    }


    /*TRIGGERS*/
    void EscapeTrigger()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            moveLock = !moveLock;
            InputOccured();
        }
    }

    void LeftMouseButtonTrigger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lmbPressed = true;
            InputOccured();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            lmbPressed = false;
            InputOccured();
        }
    }

    void FreeCloseTrigger()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            cameraClosedController.transform.gameObject.SetActive(freeCamera);
            cameraFreeController.transform.gameObject.SetActive(!freeCamera);
            freeCamera = !freeCamera;

            InputOccured();
            if (resetSettings)
            {
                cameraClosedController.ResetSettings();
                cameraFreeController.ResetSettings();
            }
        }
    } 

    void ChangeSeatTrigger()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            cameraClosedController.ChangeSeat();
            InputOccured();
        }
    }

    void IdleAnimationTrigger()
    {
        idleTime += Time.deltaTime;
        if(idleTime > maxIdleTime && !idleAnimation)
        {
            idleAnimation = true;
        }

        //Temporaty button
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (idleAnimation)
            {
                idleAnimation = false;
                idleTime = 0.0f;
            }
            else
            {
                idleAnimation = true;
                idleTime = maxIdleTime;
            }
        }
    }


    /*CHANGE METHODS*/
    void LeftMouseButtonChange()
    {
        cameraFreeController.buttonPressed = lmbPressed;
        cameraClosedController.buttonPressed = lmbPressed;
    }

    void ScrollInput()
    {
        float scrollInputValue = Input.mouseScrollDelta.y;
        cameraFreeController.scrollInput = scrollInputValue;
        cameraClosedController.scrollInput = scrollInputValue;

        if (scrollInputValue != 0.0f)
            InputOccured();
    }

    void EscapeChange()
    {
        if(moveLock)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = moveLock;
        cameraFreeController.lockMode = moveLock;
        cameraClosedController.lockMode = moveLock;
    }

    void IdleAnimation()
    {
        if (idleAnimation && !freeCamera)
        {
            cameraClosedController.transform.gameObject.SetActive(freeCamera);
            cameraFreeController.transform.gameObject.SetActive(!freeCamera);
            freeCamera = !freeCamera;
        }

        cameraFreeController.idleAnimation = idleAnimation;
    }

    void InputOccured()
    {
        idleTime = 0.0f;
        idleAnimation = false;
    }
}
