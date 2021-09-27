using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelChange : AbstractElementChange
{
    /*Params*/
    [SerializeField] PanelUI panel;

    /*Public methods*/
    public override void ChangeConfiguration()
    {
       if(Managers.allLoaded)
       {
           Managers.UI.ChangePanelOnIndex(panel);
       }
    }

    public override int GetOptionIndex()
    {
        return (int)panel;
    }
}
