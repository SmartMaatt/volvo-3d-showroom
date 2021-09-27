using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpholstingChange : AbstractElementChange
{
    /*Params*/
    [SerializeField] UpholstingUI upholsting;

    /*Public methods*/
    public override void ChangeConfiguration()
    {
        //Car upholstery change here
        if (Managers.allLoaded)
        {
            Managers.Input.SetUpholsteryColorByIndex((int)upholsting);
            Managers.Save.SetUpholsting(upholsting);
        }
    }

    public override int GetOptionIndex()
    {
        return (int)upholsting;
    }
}
