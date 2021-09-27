using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Slider))]
public class VideoSliderScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    /*Params*/
    public VideoPlayer video;
    private Slider tracking;
    private bool slide = false;


    /*Private methods*/
    private void Start()
    {
        tracking = GetComponent<Slider>();
    }

    private void Update()
    {
        if (!slide)
            tracking.value = (float)video.frame / (float)video.frameCount;
    }


    /*Public methods*/
    public void OnPointerDown(PointerEventData a)
    {
        slide = true;
    }

    public void OnPointerUp(PointerEventData a)
    {
        float frame = (float)tracking.value * (float)video.frameCount;
        video.frame = (long)frame;
        slide = false;
    }

    public void ResetSlider()
    {
        tracking.value = 0;
    }
}
