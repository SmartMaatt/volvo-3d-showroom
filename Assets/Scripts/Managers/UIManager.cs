using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IGameManager
{
    /*Params*/
    public ManagerStatus status { get; private set; }

    [Header("References")]
    [SerializeField] GameObject UIMainObject;
    [SerializeField] UIElement[] Panels;

    /*Startup*/
    public void Startup()
    {
        Debug.Log("Starting UI manager");

        status = ManagerStatus.Started;
    }

    /*Public methods*/
    public void ChangePanelOnIndex(PanelUI index)
    {
        UIElement target = Panels[(int)index];
        bool activationState = target.GetTurnedOn();

        foreach (UIElement element in Panels)
            element.TurnOff(1f);

        if (!activationState)
        {
            target.TurnOn(1f);
        }
    }

    public GameObject GetUIMainObject()
    {
        return UIMainObject;
    }
}
