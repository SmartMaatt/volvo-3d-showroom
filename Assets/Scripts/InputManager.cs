using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour, IGameManager
{
    /*PARAMS*/
    public ManagerStatus status { get; private set; }

    [Header("References")]
    [SerializeField] private CameraFreeController cameraFreeController;
    [SerializeField] private CameraClosedController cameraClosedController;
    [SerializeField] private ButtonToggle seatButton;

    [Space]
    public bool moveLock = false;
    public bool lmbPressed = false;
    public bool freeCamera = true;
    public bool resetSettings = false;
    public bool idleAnimation = false;

    [Space]
    public float idleTime = 0.0f;
    public float maxIdleTime = 60.0f;

    private int cameraState;

    /*PRIVATE METHODS*/
    public void Startup()
    {
        Debug.Log("Starting Input manager");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraState = 0;

        status = ManagerStatus.Started;
    }

    void Update()
    {
        EscapeTrigger();
        LeftMouseButtonTrigger();

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
        if (!lmbPressed)
        {
            if (idleAnimation && !freeCamera)
            {
                cameraClosedController.transform.gameObject.SetActive(freeCamera);
                cameraFreeController.transform.gameObject.SetActive(!freeCamera);
                freeCamera = !freeCamera;

                cameraState = 0;
                seatButton.ToggleButtonHighlight();
            }

            cameraFreeController.idleAnimation = idleAnimation;
        }
    }

    void InputOccured()
    {
        idleTime = 0.0f;
        idleAnimation = false;
    }


    /*PUBLIC METHODS*/
    public void ChangePerspective()
    {
        if (cameraState == 0 || cameraState == 5)
        {
            cameraClosedController.transform.gameObject.SetActive(freeCamera);
            cameraFreeController.transform.gameObject.SetActive(!freeCamera);
            freeCamera = !freeCamera;
            seatButton.ToggleButtonHighlight();

            InputOccured();
            if (resetSettings)
            {
                cameraClosedController.ResetSettings();
                cameraFreeController.ResetSettings();
            }

            if (cameraState == 5)
                cameraState = -1;
        }
        else
        {
            cameraClosedController.ChangeSeat();
            InputOccured();
        }

        cameraState++;
    }
}
