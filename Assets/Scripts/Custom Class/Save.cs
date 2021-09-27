using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    /*Params*/
    public string _name;
    public string _date;
    public VersionUI _version;
    public DriveUI _drive;
    public ColorUI _color;
    public UpholstingUI _upholsting;
    public bool[] _packets = new bool[4];

    /*Public Methods*/
    public Save()
    {
        _name = "EmptyName";
        _date = "";
        _version = VersionUI.Momentum;
        _drive = DriveUI.T3Manual;
        _color = ColorUI.IceWhite;
        _upholsting = UpholstingUI.Black;

        for(int i=0; i<_packets.Length; i++)
            _packets[i] = false;
    }

    public Save(string name, string date, VersionUI version, DriveUI drive, ColorUI color, UpholstingUI upholsting, bool[] packets)
    {
        _name = name;
        _date = date;
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
        _date = other._date;
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
