using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnyRightPanel : UIElement
{
    /*Params*/
    public bool defaultLoad;
    public int tweenCorrection;

    /*Private methods*/
    private void Start()
    {
        TurnedOn = defaultLoad;
        if (!defaultLoad)
            TurnOff(0);
    }

    /*Public methods*/
    public override void ReloadPanel()
    {
        ReloadLanguage();
    }

    public override void ReloadLanguage(){}
    public override void TurnOn(float time)
    {
        EnableObject();
        LeanTween.moveLocalX(gameObject, tweenCorrection + 30, time).setEaseInOutSine().setOnComplete(EnableObject);
        TurnedOn = true;
    }
    public override void TurnOff(float time)
    {
        LeanTween.moveLocalX(gameObject, tweenCorrection + 450, time).setEaseInOutSine().setOnComplete(DisableObject);
        TurnedOn = false;
    }
}
