using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPage : MonoBehaviour
{
    [SerializeField] string link;

    public void OpenPageFromLink()
    {
        Application.OpenURL(link);
    }
}
