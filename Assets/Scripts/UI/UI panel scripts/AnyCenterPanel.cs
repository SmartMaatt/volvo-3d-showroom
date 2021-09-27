using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnyCenterPanel : UIElement
{
    /*Params*/
    public bool defaultLoad;

    private Vector3 _startLocalScale;
    private RectTransform _panelRectTransform;

    /*Private methods*/
    private void Start()
    {
        _panelRectTransform = GetComponent<RectTransform>();
        _startLocalScale = _panelRectTransform.localScale;

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
        LeanTween.scaleY(gameObject, _startLocalScale.y, time).setEaseInOutSine().setOnComplete(EnableObject);
        TurnedOn = true;
    }
    public override void TurnOff(float time)
    {
        LeanTween.scaleY(gameObject, 0, time).setEaseInOutSine().setOnComplete(DisableObject);
        TurnedOn = false;
    }
}
