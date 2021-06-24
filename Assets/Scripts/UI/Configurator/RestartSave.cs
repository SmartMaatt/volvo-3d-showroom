using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartSave : MonoBehaviour
{
    public void RestartDefaultSave()
    {
        if (Managers.allLoaded)
            Managers.Save.RestartDefaultSave();
    }
}
