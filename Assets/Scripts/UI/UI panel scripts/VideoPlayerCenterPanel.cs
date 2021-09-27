using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class VideoPlayerCenterPanel : AnyCenterPanel
{
    [Header("Language references")]
    [SerializeField] TMP_Text Header;

    [Header("References")]
    [SerializeField] PlayPauseScript playPauseScript;

    public override void ReloadLanguage()
    {
        if (!OnLanguageList)
            Managers.Language.AddToUIElementsList(GetComponent<UIElement>());

        Header.text = Managers.Language.CurrentLanguage.VideoPlayerHeader;
    }

    public override void TurnOff(float time)
    {
        playPauseScript.SetPauseMode();
        base.TurnOff(time);    
    }
}