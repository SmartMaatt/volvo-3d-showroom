using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ButtonHoverScaleAnimation : MonoBehaviour
{
    /*Params*/
    public float scope;
    public float time;
    Vector3 DefaultScale;

    /*Private methods*/
    private void Start()
    {
        DefaultScale = GetComponent<RectTransform>().localScale;
    }

    /*Public methods*/
    public void ButtonHover(bool value)
    {
        if (value)
        {
            LeanTween.scale(gameObject, DefaultScale * scope, .5f).setEaseInOutSine();
        }
        else
        {
            LeanTween.scale(gameObject, DefaultScale, .5f).setEaseInOutSine();
        }
    }
}
