using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDropdown : MonoBehaviour
{
    [SerializeField] Dropdown dropdown;
    public void LoadSaveAsCurrent()
    {
        if(dropdown.enabled)
            Managers.Save.LoadSaveAsCurrent(dropdown.value);
    }
}
