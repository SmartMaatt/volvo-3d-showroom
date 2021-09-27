using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideosSwitcher : MonoBehaviour
{
    /*Params*/
    [Header("Video manager")]
    [SerializeField] VideoClip[] videosArray;

    [Header("Video miniatures")]
    [SerializeField] VideoMiniature[] miniaturesArray;

    [Header("References")]
    [SerializeField] VideoPlayer videoPlayer;
    public int startIndex = 0;

    private int currentIndex;
    private int maxIndex;


    /*Private methods*/
    void Start()
    {
        currentIndex = startIndex;
        maxIndex = videosArray.Length - 1;
        PlayVidByIndex(0);
    }

    void IndexCorrection()
    {
        if (currentIndex < 0)
        {
            currentIndex = maxIndex;
        }
        else if (currentIndex > maxIndex)
        {
            currentIndex = 0;
        }
    }

    int IndexPrediction(int index)
    {
        if (index < 0)
        {
            return maxIndex;
        }
        else if (index > maxIndex)
        {
            return 0;
        }
        else
        {
            return index;
        }
    }

    void ChangeMiniatures()
    {
        if(miniaturesArray.Length == 3)
        {
            int currentIndexTmp = currentIndex-1;
            miniaturesArray[0].SetVideoClip(videosArray[IndexPrediction(currentIndexTmp)], IndexPrediction(currentIndexTmp));
            miniaturesArray[1].SetVideoClip(videosArray[IndexPrediction(++currentIndexTmp)], IndexPrediction(currentIndexTmp));
            miniaturesArray[2].SetVideoClip(videosArray[IndexPrediction(++currentIndexTmp)], IndexPrediction(currentIndexTmp));
        }
        else
        {
            Debug.LogWarning("Miniatures array length is not 3!!! Value: " + miniaturesArray.Length);
        }
    }

    IEnumerator PlayClip()
    {
        yield return new WaitForSeconds(.2f);
        videoPlayer.Play();
    }


    /*Public methods*/
    public void PlayVidByIndex(int index)
    {
        currentIndex = index;
        IndexCorrection();
        videoPlayer.clip = videosArray[currentIndex];

        ChangeMiniatures();
        StartCoroutine(PlayClip());
    }

    public void PlayNextVid()
    {
        currentIndex++;
        IndexCorrection();
        videoPlayer.clip = videosArray[currentIndex];

        ChangeMiniatures();
        StartCoroutine(PlayClip());
    }

    public void PlayPrevVid()
    {
        currentIndex--;
        IndexCorrection();
        videoPlayer.clip = videosArray[currentIndex];

        ChangeMiniatures();
        StartCoroutine(PlayClip());
    }
}
