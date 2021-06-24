using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationMenuPanel : UIElement
{
    [SerializeField] ToggleGroup drives;
    [SerializeField] ToggleGroup colors;
    [SerializeField] ToggleGroup upholstery;
    [SerializeField] ButtonToggle[] packetButtons;

    public override void ReloadPanel()
    {
        ReloadLanguage();

        drives.restartGroup();
        colors.restartGroup();
        upholstery.restartGroup();
        
        foreach(ButtonToggle button in packetButtons)
            button.TurnOff();
    }

    public override void ReloadLanguage()
    {
    }

    public void LoadSave()
    {
        drives.setById((int)Managers.Save.currentSave._drive);
        colors.setById((int)Managers.Save.currentSave._color);
        upholstery.setById((int)Managers.Save.currentSave._upholsting);

        for (int i = 0; i < packetButtons.Length; i++)
        {
            if (Managers.Save.currentSave._packets[i])
            {
                packetButtons[i].TurnOn();
            }
            else
            {
                packetButtons[i].TurnOff();
            }
        }
    }
}
