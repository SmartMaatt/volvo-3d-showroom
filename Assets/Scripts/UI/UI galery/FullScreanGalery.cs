using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(RectTransform))]
public class FullScreanGalery : MonoBehaviour
{
    /*Params*/
    [Header("References")]
    [SerializeField] RawImage displayImage;
    [SerializeField] TMP_Text counterText;

    int currentID;
    int maxID;

    Texture currentTexture;
    RectTransform rectTransformScript;
    Image imageScript;
    bool loaded = false;


    /*Private methods*/
    void Awake()
    {
        rectTransformScript = GetComponent<RectTransform>();
        imageScript = GetComponent<Image>();
    }

    void Start()
    {
        LeanTween.alpha(rectTransformScript, 0, 0);
        LeanTween.alpha(rectTransformScript, 1, 0.5f);
        LeanTween.value(gameObject, (float val, float ratio) =>
            imageScript.color = new Color(imageScript.color.r, imageScript.color.g, imageScript.color.b, val),
            0, 0.75f, 0.5f
        ).setOnComplete(() => loaded = true);
        
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }

    void CorrectPosition()
    {
        rectTransformScript.localPosition = Vector3.zero;
    }

    string BuildCounterText(int ID, int maxID)
    {
        return (ID.ToString() + "/" + maxID.ToString());
    }


    /*Public methods*/
    public void CloseFullGalery()
    {
        LeanTween.alpha(rectTransformScript, 0, .5f).setOnComplete(DestroyMe);
    }

    public void SetUpFullScreanGalery(Texture source, int ID, int maxID)
    {
        this.currentID = ID;
        this.maxID = maxID;
        counterText.text = BuildCounterText(ID+1, maxID);

        currentTexture = source;
        displayImage.texture = currentTexture;

        CorrectPosition();
    }

    public void SkipNext()
    {
        Managers.Galery.SkipPhoto(currentID + 1);
    }

    public void SkipPrev()
    {
        Managers.Galery.SkipPhoto(currentID - 1);
    }
}
