
using System;

[System.Serializable]
public class Language
{
    /*Params*/
    public string LangName = null;
    public string FlagImageName = null;

    /*Right panel*/
    public string ConfigurationTitle = null;
    public string[] SavePanel = new string[5];
    public string[] Configurator = new string[8];
    public string[] ConfiguratorTexts = new string[3];

    public string YesNoPopUpYes = null;
    public string YesNoPopUpNo = null;
    public string[] YesNoPopUp = new string[1];

    public string OkPopUpOK = null;
    public string[] OkPopUp = new string[1];

    public string TestDriveHeader = null;
    public string[] TestDriveBooking = new string[4];
    public string[] TestDriveBooked = new string[2];

    public string PhotoGaleryHeader = null;
    public string VideoPlayerHeader = null;

    /*Public methods*/
    public Language() { }
    public Language(string _LangName,
                    string _FlagImageName,
                    string _ConfigurationTitle, 
                    string _SaveSubtitleLoad,
                    string _SaveSubtitleStart,
                    string _SaveButtonLoad,
                    string _SaveButtonStart,
                    string _NoSaveDropdown,
                    string _configVersion,
                    string _configDrive,
                    string _configColor,
                    string _configUpholstery,
                    string _configPackets,
                    string _configName,
                    string _configButtonReturn,
                    string _configButtonSave,
                    string _configMomentumText,
                    string _configInscriptionText,
                    string _configRDesignText,
                    string _yesNoPopUpYes,
                    string _yesNoPopUpNo,
                    string _yesNoPopUp1ReturnPopUp,
                    string _okPopUpOK,
                    string _okPopUp1NoSaves,
                    string _testDriveHeader,
                    string _testDriveBookSubtitle,
                    string _testDriveDateText,
                    string _testDriveTimeText,
                    string _testDriveLoadButton,
                    string _testDriveBookedSubtitle,
                    string _testDriveRefreshButton,
                    string _photoGaleryHeader,
                    string _videoPlayerHeader
    )
    {
        LangName = _LangName;
        FlagImageName = _FlagImageName;

        ConfigurationTitle = _ConfigurationTitle;
        SavePanel[0] = _SaveSubtitleLoad;
        SavePanel[1] = _SaveSubtitleStart;
        SavePanel[2] = _SaveButtonLoad;
        SavePanel[3] = _SaveButtonStart;
        SavePanel[4] = _NoSaveDropdown;

        Configurator[0] = _configVersion;
        Configurator[1] = _configDrive;
        Configurator[2] = _configColor;
        Configurator[3] = _configUpholstery;
        Configurator[4] = _configPackets;
        Configurator[5] = _configName;
        Configurator[6] = _configButtonReturn;
        Configurator[7] = _configButtonSave;

        ConfiguratorTexts[0] = _configMomentumText;
        ConfiguratorTexts[1] = _configInscriptionText;
        ConfiguratorTexts[2] = _configRDesignText;

        YesNoPopUpYes = _yesNoPopUpYes;
        YesNoPopUpNo = _yesNoPopUpNo;
        YesNoPopUp[0] = _yesNoPopUp1ReturnPopUp.Replace("#", Environment.NewLine);

        OkPopUpOK = _okPopUpOK;
        OkPopUp[0] = _okPopUp1NoSaves.Replace("#", Environment.NewLine);

        TestDriveHeader = _testDriveHeader;
        TestDriveBooking[0] = _testDriveBookSubtitle;
        TestDriveBooking[1] = _testDriveDateText;
        TestDriveBooking[2] = _testDriveTimeText;
        TestDriveBooking[3] = _testDriveLoadButton;

        TestDriveBooked[0] = _testDriveBookedSubtitle;
        TestDriveBooked[1] = _testDriveRefreshButton;

        PhotoGaleryHeader = _photoGaleryHeader;
        VideoPlayerHeader = _videoPlayerHeader;
    }
}
