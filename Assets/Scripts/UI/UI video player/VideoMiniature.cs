using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoMiniature : MonoBehaviour
{
    /*Params*/
    [SerializeField] VideosSwitcher switcher;
    [SerializeField] VideoPlayer videoPlayer;
    public int playIndex;

    /*Private methods*/
    private void Start()
    {
        videoPlayer.Stop();        
    }

    /*Public methods*/
    public void SetVideoClip(VideoClip clip, int index)
    {
        this.videoPlayer.clip = clip;
        this.playIndex = index;
    }

    public void PlayVideoByIndex()
    {
        this.switcher.PlayVidByIndex(playIndex);
    }
}
