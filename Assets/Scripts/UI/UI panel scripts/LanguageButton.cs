using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class LanguageButton : UIElement
{
    /*Params*/
    [SerializeField] Texture emptyFlag;
    private RawImage rawImageComponent;

    /*Private methods*/
    private void Awake()
    {
        rawImageComponent = GetComponent<RawImage>();
        ReloadLanguage();
    }

    /*Public methods*/
    public override void ReloadPanel() { }

    public override void ReloadLanguage()
    {
        if (!OnLanguageList)
            Managers.Language.AddToUIElementsList(GetComponent<UIElement>());

        Texture newTexture = Managers.Language.GetCurrentFlag();
        if (newTexture != null)
            rawImageComponent.texture = newTexture;
        else
            rawImageComponent.texture = emptyFlag;
    }

    public void ChangeLanguage()
    {
        Managers.Language.ChangeLanguage();
    }
}
