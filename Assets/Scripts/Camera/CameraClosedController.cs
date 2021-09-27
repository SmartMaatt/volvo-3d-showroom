using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClosedController : MonoBehaviour
{
    /*Params*/
    [Header("Objects")]
    public GameObject CameraObj;

    [Header("StateMachine")]
    public int activeSeat = 0;
    public bool lockMode = false;
    public bool buttonPressed = false;
    [HideInInspector]
    public float scrollInput = 0.0f;

    [Header("SeatInfo")]
    public SeatConfig[] seatArray;
    private CameraClosedLook _closedLookComponent = null;


    /*Private methods*/
    void Awake()
    {
        _closedLookComponent = CameraObj.GetComponent<CameraClosedLook>();
        activeSeat = seatArray.Length;
        ChangeSeat();
    }

    void Update()
    {
        ChangeLockMode();
        ChangeButtonPressed();
        ScrollInput();
    }

    void ChangeLockMode()
    {
        if (_closedLookComponent)
            _closedLookComponent.SetLockMode(lockMode);
    }

    void ChangeButtonPressed()
    {
        if (_closedLookComponent)
            _closedLookComponent.SetButtonPressed(buttonPressed);
    }

    void ScrollInput()
    {
        if (_closedLookComponent)
            _closedLookComponent.Scrolling(scrollInput);
    }


    /*Public methods*/
    public void ChangeSeat()
    {
        if (activeSeat >= seatArray.Length - 1)
            activeSeat = 0;
        else
            activeSeat++;

        CameraObj.transform.position = seatArray[activeSeat].position;
        CameraObj.transform.eulerAngles = seatArray[activeSeat].rotation;

        if (_closedLookComponent)
            _closedLookComponent.ResetFieldOfView();
    }

    public void ResetSettings()
    {
        activeSeat = seatArray.Length;
        ChangeSeat();
    }


    /*ADDITIONAL CLASSES*/
    [System.Serializable]
    public class SeatConfig
    {
        public Vector3 position;
        public Vector3 rotation;
    }
}
