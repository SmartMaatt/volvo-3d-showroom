using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : MonoBehaviour
{
    /*Params*/
    [SerializeField] string PopUpName;
    [SerializeField] ConfigurationMenuToggle RightPanelManagement;
    [SerializeField] GameObject SavePanel;

    /*Public methods*/
    public void RestartDefaultSave()
    {
        if (Managers.allLoaded)
            Managers.PopUp.SetUpYesNoPopUp(PopUpName, delegate { Managers.Save.RestartDefaultSave(); RightPanelManagement.SelectPanel(SavePanel); }, delegate { });
    }
}
