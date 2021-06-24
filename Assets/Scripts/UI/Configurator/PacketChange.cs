using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacketChange : MonoBehaviour
{
    [SerializeField] PacketsUI packet;
    public bool value;

    public void ChangePacket()
    {
        value = !value;
        if (Managers.allLoaded)
            Managers.Save.SetPacket(value, (int)packet);
    }
}
