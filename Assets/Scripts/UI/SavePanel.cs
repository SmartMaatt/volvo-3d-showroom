using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePanel : UIElement
{
    [SerializeField] Dropdown dropdown;

    private void Start()
    {
        ReloadPanel();
    }

    public override void ReloadPanel()
    {
        ReloadLanguage();

        if(Managers.Save.saves.Count > 1)
        {
            dropdown.ClearOptions();
            List<string> m_DropOptions = new List<string>();

            for (int i=0; i < Managers.Save.saves.Count; i++)
            {
                m_DropOptions.Add(Managers.Save.saves[i]._name);
            }
            dropdown.AddOptions(m_DropOptions);
        }
        else if(Managers.Save.saves.Count == 1)
        {
            dropdown.enabled = true;
            dropdown.ClearOptions();

            List<string> m_DropOptions = new List<string> {Managers.Save.saves[0]._name};
            dropdown.AddOptions(m_DropOptions);
        }
        else
        {
            dropdown.ClearOptions();
            List<string> m_DropOptions = new List<string> {"Brak zapisów!"};
            dropdown.AddOptions(m_DropOptions);
            dropdown.enabled = false;
        }
    }

    public override void ReloadLanguage()
    {
    }
}
