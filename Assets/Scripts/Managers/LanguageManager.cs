using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class LanguageManager : MonoBehaviour, IGameManager
{
    /*Params*/
    public ManagerStatus status { get; private set; }

    [Header("Configuration folder")]
    public string fileName;
    public string configDirectory;
    public string languageDirectory;

    [Header("Backup folder")]
    public string backupDirectoryPath;

    [Header("CSV configuration")]
    public int columnsCount = 8;

    public List<UIElement> uiElementsList = null;
    private string[][] languageInArray = null;

    private List<Language> LangList = null;
    private int CurrentIndex = 0;
    private Texture CurrentFlag = null;

    [HideInInspector]
    public Language CurrentLanguage = null;

    /*Startup*/
    public void Startup()
    {
        Debug.Log("Starting Language manager");

        CatchAllUIElements();
        ReadLanguageCSV(fileName, configDirectory, languageDirectory);
        GenerateLanguageList(languageInArray);
        StartCoroutine(SetUpCurrentLanguage());

        status = ManagerStatus.Started;
    }


    /*Public methods*/
    public void ChangeLanguage()
    {
        CurrentIndex++;
        if (CurrentIndex >= LangList.Count)
            CurrentIndex = 0;

        CurrentLanguage = LangList[CurrentIndex];
        StartCoroutine(SetUpCurrentLanguage());
    }

    public Texture GetCurrentFlag()
    {
        return CurrentFlag;
    }

    public void AddToUIElementsList(UIElement newElement)
    {
        this.uiElementsList.Add(newElement);
        newElement.SetOnLanguageList(true);
    }

    /*Private methods*/

    /*Setting up current language*/
    IEnumerator SetUpCurrentLanguage()
    {
        yield return SetUpFlagImage(CurrentLanguage.FlagImageName);

        foreach (UIElement panel in this.uiElementsList)
        {
            panel.ReloadLanguage();
        }
    }

    IEnumerator SetUpFlagImage(string flagFileName)
    {
        string flagPath = Path.Combine(Directory.GetCurrentDirectory(), configDirectory + "\\" + languageDirectory + "\\" + flagFileName);
        using (UnityWebRequest loader = UnityWebRequestTexture.GetTexture("file://" + flagPath))
        {
            yield return loader.SendWebRequest();

            if (string.IsNullOrEmpty(loader.error))
            {
                CurrentFlag = DownloadHandlerTexture.GetContent(loader);
            }
            else
            {
                Debug.LogWarning("Error loading Texture '{" + loader.uri + "}': {" + loader.error + "}");
                CurrentFlag = null;
            }
        }
    }

    /*Language List management*/
    void GenerateLanguageList(string[][] languageInArray)
    {
        this.LangList = new List<Language>();

        for(int i=1; i < languageInArray.Length; i++)
        {
            Language newLang = new Language(
                    languageInArray[i][0],
                    languageInArray[i][1],
                    languageInArray[i][2],
                    languageInArray[i][3],
                    languageInArray[i][4],
                    languageInArray[i][5],
                    languageInArray[i][6],
                    languageInArray[i][7],
                    languageInArray[i][8],
                    languageInArray[i][9],
                    languageInArray[i][10],
                    languageInArray[i][11],
                    languageInArray[i][12],
                    languageInArray[i][13],
                    languageInArray[i][14],
                    languageInArray[i][15],
                    languageInArray[i][16],
                    languageInArray[i][17],
                    languageInArray[i][18],
                    languageInArray[i][19],
                    languageInArray[i][20],
                    languageInArray[i][21],
                    languageInArray[i][22],
                    languageInArray[i][23],
                    languageInArray[i][24],
                    languageInArray[i][25],
                    languageInArray[i][26],
                    languageInArray[i][27],
                    languageInArray[i][28],
                    languageInArray[i][29],
                    languageInArray[i][30],
                    languageInArray[i][31],
                    languageInArray[i][32]
                );
            this.LangList.Add(newLang);
        }

        if(this.LangList.Count > 0)
        {
            this.CurrentLanguage = this.LangList[0];
        }
        else
        {
            //If no meaningful content in CSV
            FullLanguageDirectoryRecovery(this.configDirectory, this.languageDirectory, this.fileName, this.backupDirectoryPath);
            GenerateLanguageList(this.languageInArray);
        }
    }

    /*CSV read and management*/
    void ReadLanguageCSV(string fileName, string configDirectory, string languageDirectory)
    {
        string languagePath = configDirectory + "\\" + languageDirectory;
        string languageCSVPath = configDirectory + "\\" + languageDirectory + "\\" + fileName;

        //No config directory
        if (!Directory.Exists(configDirectory))
        {
            Debug.LogWarning("No directory: " + configDirectory);
            FileManagement.CreateDirectory(configDirectory);
        }

        //No language directory
        if(!Directory.Exists(languagePath))
        {
            Debug.LogWarning("No directory: " + languagePath);
            FileManagement.CreateDirectory(languagePath);
        }

        //No language CSV file
        if (!File.Exists(languageCSVPath))
        {
            Debug.LogWarning("No file: " + languageCSVPath);
            FileManagement.DirectoryCopy(backupDirectoryPath, languagePath, false);
        }

        //Check if file is valid
        if (!ReadLanguageCSVWithValidation(languageCSVPath))
        {
            Debug.LogWarning("File: " + fileName + " is not valid! Loading recovery and saving old files");
            FullLanguageDirectoryRecovery(configDirectory, languageDirectory, fileName, backupDirectoryPath);
        }

    }


    bool ReadLanguageCSVWithValidation(string path)
    {
        StreamReader sr = new StreamReader(path);
        var lines = new List<string[]>();

        int Row = 0;
        int Col = 0;
        while (!sr.EndOfStream)
        {
            string[] Line = sr.ReadLine().Split(';');
            lines.Add(Line);
            Row++;

            foreach(string word in Line)
            {
                if(word == "")
                {
                    sr.Close();
                    return false;
                }
                Col++;    
            }

            if(Col != columnsCount)
            {
                sr.Close();
                return false;
            }

            Col = 0;
        }
        sr.Close();

        if (Row < 1)
        {
            return false;
        }
        else
        {
            languageInArray = lines.ToArray();
            return true;
        }
    }

    void ReadLanguageCSVWithoutValidation(string path)
    {
        StreamReader sr = new StreamReader(path);
        var lines = new List<string[]>();

        int Row = 0;
        while (!sr.EndOfStream)
        {
            string[] Line = sr.ReadLine().Split(';');
            lines.Add(Line);
            Row++;
        }
        sr.Close();

        languageInArray = lines.ToArray();
    }


    void RecoverLanguageDirectory(string configDir, string langDir, string recoveryDirPath)
    {
        //Saving old files
        if (Directory.Exists(configDir + "\\" + langDir + "_backup"))
        {
            Directory.Delete(configDir + "\\" + langDir + "_backup", true);
        }

        FileManagement.DirectoryCopy(configDir + "\\" + langDir, configDir + "\\" + langDir + "_backup", false);
        Directory.Delete(configDir + "\\" + langDir, true);

        //Recover config files
        FileManagement.DirectoryCopy(recoveryDirPath, configDir + '\\' + langDir, false);
    }

    void FullLanguageDirectoryRecovery(string configDir, string langDir, string fileName, string recoveryDir)
    {
        RecoverLanguageDirectory(configDir, langDir, recoveryDir);
        ReadLanguageCSVWithoutValidation(configDir + "\\" + langDir + "\\" + fileName);
    }

    /*UI elements reference*/
    void CatchAllUIElements()
    {
        this.uiElementsList = new List<UIElement>();
        UIElement[] tmpArray = FindObjectsOfType<UIElement>();

        foreach(UIElement element in tmpArray)
        {
            if(!element.GetOnLanguageList())
                AddToUIElementsList(element);
        }
    }
}
