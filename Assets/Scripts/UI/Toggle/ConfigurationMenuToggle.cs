using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationMenuToggle : MonoBehaviour
{
    [SerializeField] GameObject[] panels;

    public void SelectPanel(GameObject target)
    {
        bool panelInBase = false;
        foreach (GameObject panel in panels)
        {
            if (panel == target)
                panelInBase = true;
        }

        if (panelInBase)
        {
            foreach (GameObject panel in panels)
            {
                panel.SetActive(false);
            }

            target.SetActive(true);

            if(target.GetComponent<UIElement>())
                target.GetComponent<UIElement>().ReloadPanel();

            VersionUI currentVersion = Managers.Save.currentSave._version;
            switch (currentVersion)
            {
                case VersionUI.Momentum:
                    Managers.Save.currentSave._drive = DriveUI.T3Manual;
                break;

                case VersionUI.Inscription:
                case VersionUI.RDesign:
                    Managers.Save.currentSave._drive = DriveUI.T3Automatic;
                break;
            }
            Managers.Save.currentSave._color = ColorUI.BlackStone;
            Managers.Save.currentSave._upholsting = UpholstingUI.Black;
            Managers.Save.ClearPacket(false);
        }
    }

    public void SelectPanelWithLoad()
    {
        int savesCount = Managers.Save.saves.Count;
        if (savesCount > 0)
        {
            if(savesCount <= panels.Length && (int)Managers.Save.currentSave._version < panels.Length)
            {
                Save currentSave = Managers.Save.currentSave;
                foreach (GameObject panel in panels)
                {
                    panel.SetActive(false);
                }
                GameObject chosenPanel = panels[(int)currentSave._version];
                chosenPanel.SetActive(true);

                if (chosenPanel.GetComponent<ConfigurationMenuPanel>())
                    chosenPanel.GetComponent<ConfigurationMenuPanel>().LoadSave();
            }
            else
            {
                Debug.LogWarning("Saves out of range!");
            }
        }
        else
        {
            Debug.LogWarning("No saves to load!");
        }
    }
}
