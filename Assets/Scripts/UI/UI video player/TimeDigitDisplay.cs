using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class TimeDigitDisplay : MonoBehaviour
{
    /*Params*/
    [SerializeField] VideoPlayer video;
    [SerializeField] TMP_Text timeText;


    /*Private methods*/
    void Update()
    {
        timeText.text = SetCurrentTimeUI() + " / " + SetTotalTimeUI();
    }

    string SetCurrentTimeUI()
    {
        string minutes = Mathf.Floor((int)video.time / 60).ToString("00");
        string seconds = ((int)video.time % 60).ToString("00");

        return minutes + ":" + seconds;
    }

    string SetTotalTimeUI()
    {
        string minutes = Mathf.Floor((int)video.clip.length / 60).ToString("00");
        string seconds = ((int)video.clip.length % 60).ToString("00");

        return minutes + ":" + seconds;
    }
}
