using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class GaleryManager : MonoBehaviour, IGameManager
{
    /*Params*/
    public ManagerStatus status { get; private set; }

    [Header("References")]
    [SerializeField] GameObject GaleryScrollRect;
    [SerializeField] GameObject GaleryContainer;
    [SerializeField] TMP_Text ErrorText;
    [SerializeField] GameObject GaleryElementPrefab;
    [SerializeField] GameObject FullScreanGaleryPrefab;

    [Header("Photos content folder")]
    public string configDirectory;
    public string photosContentDirectory;

    [Header("Configuration")]
    public string[] avaibleExtensions;

    ScrollRect galeryScrollRectComponent;
    string[] photosPaths = null;
    List<GameObject> galeryImplementation = new List<GameObject>();
    List<Texture> galeryTextures = new List<Texture>();
    Texture currentTexture = null;
    GameObject CurrentFullScreanGalery = null;

    /*Startup*/
    public void Startup()
    {
        Debug.Log("Starting Galery manager");
        galeryScrollRectComponent = GaleryScrollRect.GetComponent<ScrollRect>();

        ReadGaleryFiles(configDirectory, photosContentDirectory);
        StartCoroutine(GeneratePhotoGalery(photosPaths));

        status = ManagerStatus.Started;
    }

    /*Private methods*/
    void ReadGaleryFiles(string configDirectory, string photosContentDirectory)
    {
        string photosContentPath = configDirectory + "\\" + photosContentDirectory;

        //No config directory
        if (!Directory.Exists(configDirectory))
        {
            Debug.LogWarning("No directory: " + configDirectory);
            FileManagement.CreateDirectory(configDirectory);
        }

        //No language directory
        if (!Directory.Exists(photosContentPath))
        {
            Debug.LogWarning("No directory: " + photosContentPath);
            FileManagement.CreateDirectory(photosContentPath);
        }

        ProcessDirectory(photosContentPath);
    }

    void ProcessDirectory(string targetDirectory)
    {
        this.photosPaths = Directory.GetFiles(targetDirectory);
    }

    /**************************/
    IEnumerator GeneratePhotoGalery(string[] paths)
    {
        if (paths.Length > 0)
        {
            foreach (string path in paths)
            {
                if(FileManagement.CheckExtensions(path, avaibleExtensions))
                {
                    GameObject photoImplementation = Instantiate(GaleryElementPrefab);

                    RawImage photoImageSource = photoImplementation.GetComponent<RawImage>();
                    RectTransform photoImageTransform = photoImplementation.GetComponent<RectTransform>();

                    yield return GetImageFromSource(path);

                    if (currentTexture != null)
                    {
                        photoImageSource.texture = currentTexture;
                        photoImplementation.transform.parent = GaleryContainer.transform;
                        photoImageTransform.localScale = Vector3.one;
                        photoImplementation.GetComponent<PhotoScrollRaycast>().scrollRect = galeryScrollRectComponent;
                        photoImplementation.GetComponent<FullScreanGaleryDisplay>().id = galeryImplementation.Count;

                        if ((galeryImplementation.Count % 3) == 0)
                        {
                            GaleryContainer.GetComponent<GaleryContainerExpand>().ExpandGaleryContainer();
                        }

                        galeryImplementation.Add(photoImplementation);
                        galeryTextures.Add(photoImageSource.texture);
                    }
                    else
                    {
                        Destroy(photoImplementation);
                        Debug.Log(path + " texture is not valid");
                    }
                }
                else
                {
                    Debug.Log(path + " is not valid!");
                }
            }

            if(galeryImplementation.Count == 0)
                DisplayError("Photo content is empty!");
        }
        else
        {
            DisplayError("Photo content is empty!");
            Debug.Log("Photo content is empty!");
        }

        yield return null;
    }

    IEnumerator GetImageFromSource(string sourcePath)
    {
        string completePath = Path.Combine(Directory.GetCurrentDirectory(), sourcePath);
        using (UnityWebRequest loader = UnityWebRequestTexture.GetTexture("file://" + completePath))
        {
            yield return loader.SendWebRequest();

            if (string.IsNullOrEmpty(loader.error))
            {
                currentTexture = DownloadHandlerTexture.GetContent(loader);
            }
            else
            {
                Debug.LogWarning("Error loading Texture '{" + loader.uri + "}': {" + loader.error + "}");
                currentTexture = null;
            }

            yield return null;
        }
    }


    void DisplayError(string msg)
    {
        ErrorText.transform.gameObject.SetActive(true);
        ErrorText.text = msg;
    }

    /*Public methods*/
    public void OpenFullScreanGalery(int id)
    {
        if(id < galeryImplementation.Count)
        {
            CurrentFullScreanGalery = Instantiate(FullScreanGaleryPrefab);

            CurrentFullScreanGalery.transform.parent = Managers.UI.GetUIMainObject().transform;
            CurrentFullScreanGalery.GetComponent<FullScreanGalery>().SetUpFullScreanGalery(galeryTextures[id], id, galeryTextures.Count);
        }
        else
        {
            Debug.LogWarning("Given ID: " + id + " is out of range!");
        }
    }

    public void SkipPhoto(int ID)
    {
        if (CurrentFullScreanGalery != null)
        {
            if (galeryTextures.Count > 0)
            {
                if (ID < 0)
                    CurrentFullScreanGalery.GetComponent<FullScreanGalery>().SetUpFullScreanGalery(galeryTextures[(galeryTextures.Count) - 1], (galeryTextures.Count) - 1, galeryTextures.Count);
                else if (ID >= galeryTextures.Count)
                    CurrentFullScreanGalery.GetComponent<FullScreanGalery>().SetUpFullScreanGalery(galeryTextures[0], 0, galeryTextures.Count);
                else
                    CurrentFullScreanGalery.GetComponent<FullScreanGalery>().SetUpFullScreanGalery(galeryTextures[ID], ID, galeryTextures.Count);
            }
            else
            {
                Debug.LogWarning("No photos to display!");
            }
        }
        else
        {
            Debug.LogWarning("No Full screan galery!");
        }
    }
}
