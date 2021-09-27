using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDropdown : MonoBehaviour
{
    /*Params*/
    [SerializeField] Dropdown dropdown;

    /*Public methods*/
    public void LoadSaveAsCurrent()
    {
        if (dropdown.enabled)
            Managers.Save.LoadSaveAsCurrent(dropdown.value);
        else
            Managers.PopUp.SetUpOkPopUp("NoSaves", delegate { });
    }
}
