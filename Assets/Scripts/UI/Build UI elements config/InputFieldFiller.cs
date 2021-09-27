using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class InputFieldFiller : MonoBehaviour
{
    /*Params*/
    [SerializeField] string text;
    InputField inputField;

    /*Private methods*/
    private void Awake()
    {
        inputField = GetComponent<InputField>();
        inputField.text = text;
    }

    /*Public methods*/
    public void FillIfEmpty()
    {
        if (inputField.text == string.Empty)
            inputField.text = text;
    }

    public void RestartField()
    {
        inputField.text = text;
        Managers.Save.SetName(text);
    }
}
