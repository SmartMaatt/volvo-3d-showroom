using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersionChange : MonoBehaviour
{
    [SerializeField] VersionUI version;

    public void ChangeVersion()
    {
        if (Managers.allLoaded)
            Managers.Save.SetVersion(version);
    }
}
