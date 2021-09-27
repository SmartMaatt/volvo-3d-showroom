using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveChange : AbstractElementChange
{
    /*Params*/
    [SerializeField] DriveUI drive;

    /*Public methods*/
    public override void ChangeConfiguration()
    {
        if (Managers.allLoaded)
            Managers.Save.SetDrive(drive);
    }

    public override int GetOptionIndex()
    {
        return (int)drive;
    }
}
