using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextColor : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    [Header("Color")]
    public string colorName;

    private Color backgroundColor;

    void Start()
    {
        backgroundColor = Managers.Color.GetColor(colorName);
        text.color = backgroundColor;
    }
}
