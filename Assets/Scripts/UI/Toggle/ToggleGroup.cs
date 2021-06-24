using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGroup : MonoBehaviour
{
   [SerializeField] UIToggle[] toggleElements;

   public void toggleGroup(UIToggle target)
   {
        foreach(UIToggle element in toggleElements)
            element.TurnOff();

        target.TurnOn();
   }

    public void restartGroup()
    {
        for(int i=1; i<toggleElements.Length; i++)
        {
            toggleElements[i].TurnOff();
        }
        toggleElements[0].TurnOn();
    }

    public void setById(int id)
    {
        if(id < toggleElements.Length)
        {
            foreach (UIToggle element in toggleElements)
                element.TurnOff();

            toggleElements[id].TurnOn();
            Debug.Log(toggleElements[id]);
        }
        else
        {
            Debug.LogWarning("Id out of range!");
        }
    }
}
