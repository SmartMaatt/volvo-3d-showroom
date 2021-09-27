using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacketChange : AbstractElementChange
{
    /*Params*/
    [SerializeField] PacketsUI packet;
    public bool value;

    /*Public methods*/
    public override void ChangeConfiguration()
    {
        value = !value;
        if (Managers.allLoaded)
            Managers.Save.SetPacket(value, (int)packet);
    }

    public override int GetOptionIndex()
    {
        return (int)packet;
    }
}
