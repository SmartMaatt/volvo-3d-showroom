using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(Image))]
public class VideoVolumeScript : MonoBehaviour
{
    /*Params*/
    [Header("Sprites")]
    [SerializeField] Sprite NoSound;
    [SerializeField] Sprite Sound1;
    [SerializeField] Sprite Sound2;
    [SerializeField] Sprite Sound3;
    [Space]
    [SerializeField] AudioSource Audio;
    public int maxMode = 3;

    private int mode;
    private Image imageScript;


    /*Private methods*/
    private void Start()
    {
        imageScript = GetComponent<Image>();
        SwitchVolume();
    }


    /*Public methods*/
    public void ChangeIcon(int index)
    {
        switch (index)
        {
            case 0:
                imageScript.sprite = NoSound;
                break;
            case 1:
                imageScript.sprite = Sound1;
                break;
            case 2:
                imageScript.sprite = Sound2;
                break;
            case 3:
                imageScript.sprite = Sound3;
                break;
        }
    }

    public void SwitchVolume()
    {
        mode++;
        if (mode < 0 || mode > maxMode)
            mode = 0;

        ChangeIcon(mode);
        switch(mode)
        {
            case 0:
                Audio.volume = 0;
                break;
            case 1:
                Audio.volume = 0.33f;
                break;
            case 2:
                Audio.volume = 0.67f;
                break;
            case 3:
                Audio.volume = 1;
                break;
        } 
    }
}
