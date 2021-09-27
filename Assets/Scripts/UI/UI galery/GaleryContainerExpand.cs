using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class GaleryContainerExpand : MonoBehaviour
{
    /*Params*/
    public int heightPerRow;
    RectTransform transformScript;

    /*Private methods*/
    void Start()
    {
        transformScript = GetComponent<RectTransform>();
    }

    /*Public methods*/
    public void ExpandGaleryContainer()
    {
        transformScript.sizeDelta = new Vector2(transformScript.sizeDelta.x, transformScript.sizeDelta.y + heightPerRow);
        //transformScript.position = new Vector3(transformScript.position.x, 0, transformScript.position.z);
    }

    public void NarrowGaleryContainer()
    {
        transformScript.sizeDelta = new Vector2(transformScript.sizeDelta.x, transformScript.sizeDelta.y - heightPerRow);
        //transformScript.position = new Vector3(transformScript.position.x, 0, transformScript.position.z);
    }
}
