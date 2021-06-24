using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveChange : MonoBehaviour
{
    [SerializeField] DriveUI drive;

    public void ChangeDrive()
    {
        if (Managers.allLoaded)
            Managers.Save.SetDrive(drive);
    }
}
