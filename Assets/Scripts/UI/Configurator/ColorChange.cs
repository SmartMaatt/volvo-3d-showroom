using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] ColorUI color;

    public void ChangeColor()
    {
        //Change car color here
        if (Managers.allLoaded)
            Managers.Save.SetColor(color);
    }
}
