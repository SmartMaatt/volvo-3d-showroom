using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpholstingChange : MonoBehaviour
{
    [SerializeField] UpholstingUI upholsting;

    public void ChangeUpholsting()
    {
        //Car upholsting change here
        if (Managers.allLoaded)
            Managers.Save.SetUpholsting(upholsting);
    }
}
