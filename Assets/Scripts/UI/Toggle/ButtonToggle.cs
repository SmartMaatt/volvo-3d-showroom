using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToggle : UIToggle
{
    [SerializeField] Image sourceImage;
    public bool startValue;

    [Header("Color")]
    public string enabled;
    public string dissabled;

    private bool state;
    private Color dissabledColor;
    private Color enabledColor;

    void Awake()
    {
        if (Managers.allLoaded)
        {
            dissabledColor = Managers.Color.GetColor(dissabled);
            enabledColor = Managers.Color.GetColor(enabled);
            state = startValue;

            if (startValue)
                sourceImage.color = enabledColor;
            else
                sourceImage.color = dissabledColor;
        }   
    }
    
    public override void ToggleButtonHighlight()
    {
        state = !state;
        if (state)
            sourceImage.color = enabledColor;
        else
            sourceImage.color = dissabledColor;
    }

    public override void TurnOn()
    {
        state = true;
        sourceImage.color = enabledColor;
    }

    public override void TurnOff()
    {
        state = false;
        sourceImage.color = dissabledColor;
    }
}
