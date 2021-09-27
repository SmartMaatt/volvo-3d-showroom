using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class NameChange : MonoBehaviour
{
    /*Params*/
    private InputField inputField;

    /*Private methods*/
    private void Awake()
    {
        inputField = GetComponent<InputField>();   
    }

    /*Public methods*/
    public void ChangeConfiguration()
    {
        if (Managers.allLoaded)
            Managers.Save.SetName(inputField.text);
    }
}
