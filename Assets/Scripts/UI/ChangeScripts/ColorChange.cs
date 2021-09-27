using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : AbstractElementChange
{
    /*Params*/
    [SerializeField] ColorUI color;

    /*Public methods*/
    public override void ChangeConfiguration()
    {
        if (Managers.allLoaded)
        {
            Managers.Input.SetCarColorByIndex((int)color);
            Managers.Save.SetColor(color);
        }
    }

    public override int GetOptionIndex()
    {
        return (int)color;
    }
}
