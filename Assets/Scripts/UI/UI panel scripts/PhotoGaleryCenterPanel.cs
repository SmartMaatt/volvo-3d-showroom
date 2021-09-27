using UnityEngine;
using TMPro;

public class PhotoGaleryCenterPanel : AnyCenterPanel
{
    [Header("Language references")]
    [SerializeField] TMP_Text Header;

    public override void ReloadLanguage()
    {
        if (!OnLanguageList)
            Managers.Language.AddToUIElementsList(GetComponent<UIElement>());

        Header.text = Managers.Language.CurrentLanguage.PhotoGaleryHeader;
    }
}