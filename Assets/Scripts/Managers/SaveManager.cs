using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour, IGameManager
{
    /*Params*/
    public ManagerStatus status { get; private set; }
    public string SavePath;

    public List<Save> saves;
    public Save currentSave;

    /*Startup*/
    public void Startup()
    {
        Debug.Log("Starting save and load manager");

        saves = new List<Save>();
        currentSave = new Save();

        LoadSaveFiles();

        status = ManagerStatus.Started;
    }

    /*Public methods*/
    public void SaveCurrentFile()
    {
        Debug.Log("SaveCurrentFile");
        saves.Add(currentSave);

        System.IO.Directory.CreateDirectory(Application.persistentDataPath + SavePath);
        currentSave._date = System.DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss");
        string saveData = JsonUtility.ToJson(currentSave, true);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, SavePath + "/" + currentSave._name + " - " + currentSave._date + ".save"));
        bf.Serialize(file, saveData);
        file.Close();

        currentSave = new Save();  
    }

    public void LoadSaveFiles()
    {
        Debug.Log("LoadSaveFiles");
        if (Directory.Exists(Application.persistentDataPath + SavePath))
        {
            string[] filePaths = Directory.GetFiles(Application.persistentDataPath + SavePath);

            foreach (string filePath in filePaths)
            {
                Save saveLoad = new Save();

                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(filePath, FileMode.Open);
                JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), saveLoad);
                file.Close();

                saves.Add(saveLoad);
            }
        }
        else
        {
            Debug.LogWarning("Path " + Application.persistentDataPath + SavePath + " does not exist!");
        }
    }

    public void LoadSaveAsCurrent(int val)
    {
        currentSave = new Save(saves[val]);
    }

    public void SetName(string name)
    {
        currentSave._name = name;
    }

    public void SetVersion(VersionUI version)
    {
        currentSave._version = version;
    }

    public void SetDrive(DriveUI drive)
    {
        currentSave._drive = drive;
    }

    public void SetColor(ColorUI color)
    {
        currentSave._color = color;
    }

    public void SetUpholsting(UpholstingUI upholsting)
    {
        currentSave._upholsting = upholsting;
    }

    public void SetPacket(bool value, int index)
    {
        currentSave._packets[index] = value;
    }

    public void ClearPacket(bool value)
    {
        for(int i=0; i<currentSave._packets.Length; i++)
        {
            currentSave._packets[i] = value;
        }
    }

    public void RestartDefaultSave()
    {
        currentSave = new Save();
    }
}
