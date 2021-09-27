using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(Image))]
public class PlayPauseScript : MonoBehaviour
{
    /*Params*/
    [SerializeField] Sprite play;
    [SerializeField] Sprite pause;
    [SerializeField] VideoPlayer Player;
    [SerializeField] AudioSource Audio;

    private bool playVideo;
    private Image imageScript;


    /*Private methods*/
    private void Start()
    {
        imageScript = GetComponent<Image>();
        SetPauseMode();
    }


    /*Public methods*/
    public void SetPauseMode()
    {
        imageScript.sprite = play;
        playVideo = false;
    }

    public void SetPlayMode()
    {
        imageScript.sprite = pause;
        playVideo = true;
    }

    public void RunPauseVideoPlayer()
    {
        if (playVideo)
        {
            Player.Pause();
            Audio.enabled = false;
            SetPauseMode();
        }
        else
        {
            Player.Play();
            Audio.enabled = true;
            SetPlayMode();
        }
    }
}
