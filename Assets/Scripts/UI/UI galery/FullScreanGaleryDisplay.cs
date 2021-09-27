using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreanGaleryDisplay : MonoBehaviour
{
    public int id;

    public void DisplayFullScreanGalery()
    {
        if(Managers.allLoaded)
        {
            Managers.Galery.OpenFullScreanGalery(id);
        }
    }
}
