using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationMenuToggle : MonoBehaviour
{
    /*Params*/
    [SerializeField] GameObject[] panels;


    /*Public methods*/
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
                if (panel.GetComponent<UIElement>())
                    panel.GetComponent<UIElement>().TurnOff(1f);
            }

            if (target.GetComponent<UIElement>())
            {
                target.GetComponent<UIElement>().TurnOn(1f);
                target.GetComponent<UIElement>().ReloadPanel();
            }

            VersionUI currentVersion = Managers.Save.currentSave._version;
            switch (currentVersion)
            {
                case VersionUI.Momentum:
                    Managers.Save.SetDrive(DriveUI.T3Manual);
                    Managers.Save.SetColor(ColorUI.IceWhite);
                    Managers.Save.SetUpholsting(UpholstingUI.Black);
                    break;

                case VersionUI.Inscription:
                    Managers.Save.SetDrive(DriveUI.T3Automatic);
                    Managers.Save.SetColor(ColorUI.IceWhite);
                    Managers.Save.SetUpholsting(UpholstingUI.Black);
                    break;

                case VersionUI.RDesign:
                    Managers.Save.SetDrive(DriveUI.T3Automatic);
                    Managers.Save.SetColor(ColorUI.ItsGreen);
                    Managers.Save.SetUpholsting(UpholstingUI.White);
                    break;
            }
            Managers.Save.ClearPacket(false);
        }
    }

    public void SelectPanelWithLoad()
    {
        int savesCount = Managers.Save.saves.Count;
        if (savesCount > 0)
        {
            if((int)Managers.Save.currentSave._version < panels.Length)
            {
                Save currentSave = Managers.Save.currentSave;
                foreach (GameObject panel in panels)
                {
                    if (panel.GetComponent<UIElement>())
                        panel.GetComponent<UIElement>().TurnOff(1f);
                }

                GameObject chosenPanel = panels[(int)currentSave._version];
                if (chosenPanel.GetComponent<UIElement>())
                {
                    chosenPanel.GetComponent<UIElement>().TurnOn(1f);
                }

                ConfigurationMenuPanel panelConfig = chosenPanel.GetComponent<ConfigurationMenuPanel>();
                if (panelConfig)
                {
                    panelConfig.RestartScroll();
                    panelConfig.LoadSave();
                }
                    
            }
            else
            {
                Debug.LogWarning("Saves out of range! " + savesCount + " " + panels.Length);
            }
        }
        else
        {
            Debug.LogWarning("No saves to load!");
        }
    }
}
