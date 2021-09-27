using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour, IGameManager
{
    /*Params*/
    public ManagerStatus status { get; private set; }

    [Header("Yes/No PopUps")]
    [SerializeField] List<PopUp> yesNoPopUps;

    [Header("Ok PopUps")]
    [SerializeField] List<PopUp> okPopUps;

    [Header("References")]
    [SerializeField] GameObject popUpPrefab;
    [SerializeField] GameObject UIElement;

    public delegate void YesMethods();
    public YesMethods YesMethodsDelegate;

    public delegate void NoMethods();
    public NoMethods NoMethodsDelegate;

    public delegate void OkMethods();
    public OkMethods OkMethodsDelegate;


    /*Startup*/
    public void Startup()
    {
        Debug.Log("Starting PopUp manager");
        status = ManagerStatus.Started;
    }


    /*Private methods*/
    int GetPopUpIndex(List<PopUp> array, string name)
    {
        for(int i=0; i<array.Count; i++)
        {
            if (array[i].name == name)
            {
                return i;
            }
        }
        return -1;
    }


    /*Public methods*/
    public void SetUpYesNoPopUp(string name, System.Action yesMethod, System.Action noMethod)
    {
        int PopUpIndex = GetPopUpIndex(yesNoPopUps, name);

        if(PopUpIndex < 0)
        {
            Debug.LogWarning("No \"Yes/No\" PopUp with name " + name);
            return;
        }

        GameObject PopUp = Instantiate(popUpPrefab);
        PopUp.transform.parent = UIElement.transform;

        PopUpPanel PopUpPanel = PopUp.GetComponent<PopUpPanel>();
        PopUpPanel.BuildYesNoPopUp("", yesMethod, noMethod, PopUpIndex);
    }


    public void SetUpCustomYesNoPopUp(string text, System.Action yesMethod, System.Action noMethod)
    {
        GameObject PopUp = Instantiate(popUpPrefab);
        PopUp.transform.parent = UIElement.transform;

        PopUpPanel PopUpPanel = PopUp.GetComponent<PopUpPanel>();
        PopUpPanel.BuildYesNoPopUp(text, yesMethod, noMethod, -1);
    }


    public void SetUpOkPopUp(string name, System.Action okMethod)
    {
        int PopUpIndex = GetPopUpIndex(okPopUps, name);

        if (PopUpIndex < 0)
        {
            Debug.LogWarning("No \"Ok\" PopUp with name " + name);
            return;
        }

        GameObject PopUp = Instantiate(popUpPrefab);
        PopUp.transform.parent = UIElement.transform;

        PopUpPanel PopUpPanel = PopUp.GetComponent<PopUpPanel>();
        PopUpPanel.BuildOkPopUp("", okMethod, PopUpIndex);
    }


    public void SetUpCustomOkPopUp(string text, System.Action okMethod)
    {
        GameObject PopUp = Instantiate(popUpPrefab);
        PopUp.transform.parent = UIElement.transform;

        PopUpPanel PopUpPanel = PopUp.GetComponent<PopUpPanel>();
        PopUpPanel.BuildOkPopUp(text, okMethod, -1);
    }
}
