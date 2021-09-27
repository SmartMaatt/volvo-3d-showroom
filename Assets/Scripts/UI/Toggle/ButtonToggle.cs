using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToggle : UIToggle
{
    /*Params*/
    [SerializeField] Image sourceImage;
    public bool startValue;

    [Header("Color")]
    public string enabled;
    public string dissabled;

    private bool state;
    private bool colorsLoaded;
    private Color dissabledColor;
    private Color enabledColor;


    /*Private methods*/
    void Awake()
    {
        if (Managers.allLoaded)
        {
            Config();
        }   
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        if(!colorsLoaded && Managers.allLoaded)
        {
            Config();
        }
    }

    private void Config()
    {
        dissabledColor = Managers.Color.GetColor(dissabled);
        enabledColor = Managers.Color.GetColor(enabled);
        state = startValue;
        colorsLoaded = true;

        if (startValue)
            sourceImage.color = enabledColor;
        else
            sourceImage.color = dissabledColor;
    }

    /*Public methods*/
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

    public bool GetButtonState()
    {
        return this.state;
    }
}
