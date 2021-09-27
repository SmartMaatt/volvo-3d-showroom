using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfigurationMenuPanel : UIElement
{
    /*Params*/
    [SerializeField] RectTransform content;
    [SerializeField] ToggleGroup drives;
    [SerializeField] ToggleGroup colors;
    [SerializeField] ToggleGroup upholstery;
    [SerializeField] ButtonToggle[] packetButtons;
    [SerializeField] InputField inputField;
    public bool defaultLoad;

    [Header("Default values")]
    public DriveUI defaultDrive;
    public ColorUI defaultColor;
    public UpholstingUI defaultUpholsting;

    [Header("Type of configuration")]
    [SerializeField] VersionUI version;

    [Header("Language references")]
    [SerializeField] TMP_Text configurationTitle;
    [SerializeField] TMP_Text subtitleVersion;
    [SerializeField] TMP_Text subtitleDrive;
    [SerializeField] TMP_Text subtitleColor;
    [SerializeField] TMP_Text subtitleUpholstery;
    [SerializeField] TMP_Text subtitlePackets;
    [SerializeField] TMP_Text subtitleName;
    [SerializeField] TMP_Text VersionDisc;
    [SerializeField] TMP_Text buttonReturn;
    [SerializeField] TMP_Text buttonSave;

    /*Private methods*/
    private void Start()
    {
        TurnedOn = defaultLoad;
        if (!defaultLoad)
            TurnOff(0);
    }

    /*Public methods*/
    public override void ReloadPanel()
    {
        ReloadLanguage();
        RestartScroll();

        if ((int)defaultDrive < drives.GetLengthOfToggle() && (int)defaultDrive > -1)
            drives.SetById((int)defaultDrive);
        else
            drives.RestartGroup();


        if ((int)defaultColor < colors.GetLengthOfToggle() && (int)defaultColor > -1)
        {
            Managers.Input.SetCarColorByIndex((int)defaultColor);
            colors.SetById((int)defaultColor);
        }
        else
        {
            Managers.Input.SetCarColorByIndex(0);
            colors.RestartGroup();
        }


        if ((int)defaultUpholsting < upholstery.GetLengthOfToggle() && (int)defaultUpholsting > -1)
        {
            Managers.Input.SetUpholsteryColorByIndex((int)defaultUpholsting);
            upholstery.SetById((int)defaultUpholsting);
        }
        else
        {
            Managers.Input.SetUpholsteryColorByIndex(0);
            upholstery.RestartGroup();
        }

        foreach (ButtonToggle button in packetButtons)
            button.TurnOff();

        InputFieldFiller inputFiller = inputField.gameObject.GetComponent<InputFieldFiller>();
        if (inputFiller)
            inputFiller.RestartField();
    }

    public override void ReloadLanguage()
    {
        if (!OnLanguageList)
            Managers.Language.AddToUIElementsList(GetComponent<UIElement>());

        configurationTitle.text = Managers.Language.CurrentLanguage.ConfigurationTitle;
        subtitleVersion.text = Managers.Language.CurrentLanguage.Configurator[0];
        subtitleDrive.text = Managers.Language.CurrentLanguage.Configurator[1];
        subtitleColor.text = Managers.Language.CurrentLanguage.Configurator[2];
        subtitleUpholstery.text = Managers.Language.CurrentLanguage.Configurator[3];
        subtitlePackets.text = Managers.Language.CurrentLanguage.Configurator[4];
        subtitleName.text = Managers.Language.CurrentLanguage.Configurator[5];
        buttonReturn.text = Managers.Language.CurrentLanguage.Configurator[6].ToUpper();
        buttonSave.text = Managers.Language.CurrentLanguage.Configurator[7].ToUpper();
        VersionDisc.text = Managers.Language.CurrentLanguage.ConfiguratorTexts[(int)version];
    }

    public override void TurnOn(float time)
    {
        LeanTween.moveLocalX(gameObject, 0, time).setEaseInOutSine();
        TurnedOn = true;
    }
    public override void TurnOff(float time)
    {
        LeanTween.moveLocalX(gameObject, 450, time).setEaseInOutSine();
        TurnedOn = false;
    }

    public void LoadSave()
    {
        inputField.text = Managers.Save.currentSave._name;
        drives.SetByOptionId((int)Managers.Save.currentSave._drive);

        colors.SetByOptionId((int)Managers.Save.currentSave._color);
        Managers.Input.SetCarColorByIndex((int)Managers.Save.currentSave._color);

        upholstery.SetByOptionId((int)Managers.Save.currentSave._upholsting);
        Managers.Input.SetUpholsteryColorByIndex((int)Managers.Save.currentSave._upholsting);

        for (int i = 0; i < packetButtons.Length; i++)
        {
            int optionIndex = packetButtons[i].gameObject.GetComponent<AbstractElementChange>().GetOptionIndex();
            if (Managers.Save.currentSave._packets[optionIndex])
            {
                packetButtons[i].TurnOn();
            }
            else
            {
                packetButtons[i].TurnOff();
            }
        }
    }

    public void RestartScroll()
    {
        content.position = new Vector3(content.position.x, 0, content.position.z);
    }
}
