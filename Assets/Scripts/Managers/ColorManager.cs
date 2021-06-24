using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    [SerializeField] colorProbe[] colorProbeArray;
    [Space]
    [SerializeField] Color emptyColor;

    private Hashtable hueColourValues = new Hashtable();

    public void Startup()
    {
        Debug.Log("Starting Color manager");
        AddToHashTable();
        status = ManagerStatus.Started;
    }

    private void AddToHashTable()
    {
        for(int i = 0; i < colorProbeArray.Length; i++)
        {
            hueColourValues.Add(colorProbeArray[i].name, colorProbeArray[i].color);
        }
    }

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

    [System.Serializable]
    class colorProbe
    {
        public string name;
        public Color color;
    }
}
