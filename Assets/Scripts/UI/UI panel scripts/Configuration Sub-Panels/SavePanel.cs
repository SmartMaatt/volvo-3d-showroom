using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SavePanel : UIElement
{
    /*Params*/
    [SerializeField] Dropdown dropdown;
    public bool defaultLoad;

    [Header("Language references")]
    [SerializeField] TMP_Text configurationTitle;
    [SerializeField] TMP_Text subtitleLoad;
    [SerializeField] TMP_Text subtitleStart;
    [SerializeField] TMP_Text buttonLoad;
    [SerializeField] TMP_Text buttonStart;

    private string noSaveInfo = "Error 404";


    /*Private methods*/
    private void Start()
    {
        ReloadPanel();
        TurnedOn = defaultLoad;
        if (!defaultLoad)
            TurnOff(0);
    }

    private void LoadWhenMoreThenOneSave()
    {
        dropdown.ClearOptions();

        Save tmp;
        List<string> m_DropOptions = new List<string>();
        for (int i = 0; i < Managers.Save.saves.Count; i++)
        {
            tmp = Managers.Save.saves[i];
            m_DropOptions.Add(tmp._name + " - " + tmp._date);
        }

        dropdown.AddOptions(m_DropOptions);
    }

    private void LoadWhenOneSave()
    {
        dropdown.enabled = true;
        dropdown.ClearOptions();

        Save tmp = Managers.Save.saves[0];
        List<string> m_DropOptions = new List<string> { tmp._name + " - " + tmp._date };

        dropdown.AddOptions(m_DropOptions);
    }

    private void LoadWhenNoSaves()
    {
        dropdown.ClearOptions();
        List<string> m_DropOptions = new List<string> { noSaveInfo };

        dropdown.AddOptions(m_DropOptions);
        dropdown.enabled = false;
    }


    /*Public methods*/
    public override void ReloadPanel()
    {
        ReloadLanguage();
        Managers.Input.SetCarColorByIndex((int)ColorUI.ItsGreen);

        if(Managers.Save.saves.Count > 1)
        {
            LoadWhenMoreThenOneSave();
        }
        else if(Managers.Save.saves.Count == 1)
        {
            LoadWhenOneSave();
        }
        else
        {
            LoadWhenNoSaves();
        }
    }

    public override void ReloadLanguage()
    {
        if(!OnLanguageList)
            Managers.Language.AddToUIElementsList(GetComponent<UIElement>());

        configurationTitle.text = Managers.Language.CurrentLanguage.ConfigurationTitle;
        subtitleLoad.text = Managers.Language.CurrentLanguage.SavePanel[0];
        subtitleStart.text = Managers.Language.CurrentLanguage.SavePanel[1];
        buttonLoad.text = Managers.Language.CurrentLanguage.SavePanel[2].ToUpper();
        buttonStart.text = Managers.Language.CurrentLanguage.SavePanel[3].ToUpper();

        noSaveInfo = Managers.Language.CurrentLanguage.SavePanel[4];
        if (Managers.Save.saves.Count < 1)
            LoadWhenNoSaves();
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
}
