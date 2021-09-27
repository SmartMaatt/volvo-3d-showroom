using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIElement : MonoBehaviour
{
    /*Param*/
    protected bool OnLanguageList = false;
    protected bool TurnedOn = false;

    /*Public methods*/
    public virtual void ReloadPanel(){}
    public virtual void ReloadLanguage(){}
    public virtual void TurnOn(float time){}
    public virtual void TurnOff(float time){}

    public void SetOnLanguageList(bool value)
    {
        this.OnLanguageList = value;
    }
    public bool GetOnLanguageList()
    {
        return this.OnLanguageList;
    }
    public bool GetTurnedOn()
    {
        return this.TurnedOn;
    }

    /*Protected methods*/
    protected void DisableObject()
    {
        gameObject.SetActive(false);
    }

    protected void EnableObject()
    {
        gameObject.SetActive(true);
    }
}
