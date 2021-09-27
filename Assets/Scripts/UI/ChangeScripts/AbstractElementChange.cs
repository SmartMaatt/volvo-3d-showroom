using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractElementChange : MonoBehaviour
{
    public virtual void ChangeConfiguration() { }
    public virtual int GetOptionIndex() { return 0; }
}
