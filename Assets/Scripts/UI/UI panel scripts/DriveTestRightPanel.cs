using UnityEngine;
using TMPro;

public class DriveTestRightPanel : AnyRightPanel
{
    [Header("Language references")]
    [SerializeField] TMP_Text Header;
    [Space]
    [SerializeField] TMP_Text SubtitleBookTestDrive;
    [SerializeField] TMP_Text DateText;
    [SerializeField] TMP_Text TimeText;
    [SerializeField] TMP_Text LoadButton;
    [Space]
    [SerializeField] TMP_Text SubtitleBookedTerms;
    [SerializeField] TMP_Text RefreshButton;

    public override void ReloadLanguage()
    {
        if (!OnLanguageList)
            Managers.Language.AddToUIElementsList(GetComponent<UIElement>());

        Header.text = Managers.Language.CurrentLanguage.TestDriveHeader;

        SubtitleBookTestDrive.text = Managers.Language.CurrentLanguage.TestDriveBooking[0];
        DateText.text = Managers.Language.CurrentLanguage.TestDriveBooking[1];
        TimeText.text = Managers.Language.CurrentLanguage.TestDriveBooking[2];
        LoadButton.text = Managers.Language.CurrentLanguage.TestDriveBooking[3].ToUpper();

        SubtitleBookedTerms.text = Managers.Language.CurrentLanguage.TestDriveBooked[0];
        RefreshButton.text = Managers.Language.CurrentLanguage.TestDriveBooked[1].ToUpper();
    }
}
