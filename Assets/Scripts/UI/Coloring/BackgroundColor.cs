using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundColor : MonoBehaviour
{
    [SerializeField] Image backgroundImage;

    [Header("Color")]
    public string colorName;

    private Color backgroundColor;

    void Start()
    {
        backgroundColor = Managers.Color.GetColor(colorName);
        backgroundImage.color = backgroundColor;
    }
}
