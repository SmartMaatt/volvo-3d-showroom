using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VersionUI
{
    Momentum,
    Inscription,
    RDesign
}

public enum DriveUI
{
    T3Manual,
    T3Automatic,
    B4MildHybrid,
    B4AWDMildHybrid,
    B5AWDMildHybrid
}

public enum ColorUI
{
    BlackStone,
    IceWhite,
    GlacierSilver,
    DenimBlue,
    FusionRed,
    ItsGreen
}

public enum UpholstingUI
{
    Black,
    White
}

public enum PacketsUI
{
    Winter,
    Parking,
    Technology,
    Lightning
}

[System.Serializable]
public class Save
{
    /*Params*/
    public string _name;
    public VersionUI _version;
    public DriveUI _drive;
    public ColorUI _color;
    public UpholstingUI _upholsting;
    public bool[] _packets = new bool[4];

    /*Public Methods*/
    public Save()
    {
        _name = "noname";
        _version = VersionUI.Momentum;
        _drive = DriveUI.T3Manual;
        _color = ColorUI.BlackStone;
        _upholsting = UpholstingUI.Black;

        for(int i=0; i<_packets.Length; i++)
            _packets[i] = false;
    }

    public Save(string name, VersionUI version, DriveUI drive, ColorUI color, UpholstingUI upholsting, bool[] packets)
    {
        _name = name;
        _version = version;
        _drive = drive;
        _color = color;
        _upholsting = upholsting;

        if(packets.Length <= _packets.Length)
        {
            for(int i=0; i<_packets.Length; i++)
            {
                _packets[i] = packets[i];
            }
        }
        else
        {
            for(int i=0; i<_packets.Length; i++)
            {
                _packets[i] = false;
            }

            Debug.Log("Corrupted packet array!");
        }
    }

    public Save(Save other)
    {
        _name = other._name;
        _version = other._version;
        _drive = other._drive;
        _color = other._color;
        _upholsting = other._upholsting;
        
        for(int i=0; i<_packets.Length; i++)
        {
            _packets[i] = other._packets[i];
        }
    }
}
