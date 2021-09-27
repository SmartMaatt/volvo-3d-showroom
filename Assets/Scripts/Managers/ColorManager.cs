using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour, IGameManager
{
    /*Params*/
    public ManagerStatus status { get; private set; }

    [SerializeField] ColorProbe[] colorProbeArray;
    [Space]
    [SerializeField] Color emptyColor;

    private Hashtable hueColourValues = new Hashtable();

    /*Startup*/
    public void Startup()
    {
        Debug.Log("Starting Color manager");
        AddToHashTable();
        status = ManagerStatus.Started;
    }

    /*Private methods*/
    private void AddToHashTable()
    {
        for(int i = 0; i < colorProbeArray.Length; i++)
        {
            hueColourValues.Add(colorProbeArray[i].name, colorProbeArray[i].color);
        }
    }

    /*Public methods*/
    public Color GetColor(string name)
    {
        if (hueColourValues.ContainsKey(name))
        {
            return (Color)hueColourValues[name];
        }
        else
        {
            Debug.LogError("Unknown color name: " + name);
            return emptyColor;
        }
    }

    /*Custom classes*/
    [System.Serializable]
    class ColorProbe
    {
        public string name;
        public Color color;
    }
}
