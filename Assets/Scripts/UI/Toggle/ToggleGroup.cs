using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGroup : MonoBehaviour
{
    /*Params*/
    [SerializeField] UIToggle[] toggleElements;

    private Dictionary<int, int> _buttonOrder;

    /*Private methods*/
    private void Awake()
    {
        _buttonOrder = new Dictionary<int, int>();

        for(int i=0; i < toggleElements.Length; i++)
        {
            int key = toggleElements[i].gameObject.GetComponent<AbstractElementChange>().GetOptionIndex();
            _buttonOrder.Add(key, i);
        }
    }

    /*Public methods*/
    public void ToggleGroupButtons(UIToggle target)
    {
        foreach(UIToggle element in toggleElements)
            element.TurnOff();

        target.TurnOn();
    }

    public void ToggleMenuGroupButtons(ButtonToggle target)
    {
        bool targetState = target.GetButtonState();

        foreach (UIToggle element in toggleElements)
            element.TurnOff();

        if(!targetState)
        {
            target.TurnOn();
        }
    }

    public void RestartGroup()
    {
        for(int i=1; i<toggleElements.Length; i++)
        {
            toggleElements[i].TurnOff();
        }
        toggleElements[0].TurnOn();
    }

    public void SetById(int id)
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
            Debug.LogWarning("Id out of range! (" + id + ")");
        }
    }

    public void SetByOptionId(int optionId)
    {
        if (_buttonOrder.ContainsKey(optionId))
        {
            foreach (UIToggle element in toggleElements)
                element.TurnOff();

            toggleElements[_buttonOrder[optionId]].TurnOn();
            Debug.Log(toggleElements[_buttonOrder[optionId]]);
        }
        else
        {
            Debug.LogWarning("Option ID (" + optionId + ") not found in data storage!");
        }
    }

    public int GetLengthOfToggle()
    {
        return toggleElements.Length;
    }
}
