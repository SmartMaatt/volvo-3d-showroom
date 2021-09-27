using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorToggle : UIToggle
{
    /*Params*/
    [SerializeField] GameObject frame;
    public bool startValue;

    private bool state = false;


    /*Private methods*/
    void Awake()
    {
        state = startValue;
        frame.SetActive(state);
    }
    

    /*Public methods*/
    public override void ToggleButtonHighlight()
    {
        state = !state;
        frame.SetActive(state);
    }

    public override void TurnOn()
    {
        state = true;
        frame.SetActive(state);
    }

    public override void TurnOff()
    {
        state = false;
        frame.SetActive(state);
    }
}
