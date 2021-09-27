using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersionChange : AbstractElementChange
{
    /*Params*/
    [SerializeField] VersionUI version;

    /*Public methods*/
    public override void ChangeConfiguration()
    {
        if (Managers.allLoaded)
            Managers.Save.SetVersion(version);
    }

    public override int GetOptionIndex()
    {
        return (int)version;
    }
}
