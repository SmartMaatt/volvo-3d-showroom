using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UpholsteryMaterialSet
{
    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;
    public Material material5;
    public Material material6;

    public List<Material> GetMaterialList()
    {
        List<Material> thoseMaterials = new List<Material>();
        thoseMaterials.Add(material1);
        thoseMaterials.Add(material2);
        thoseMaterials.Add(material3);
        thoseMaterials.Add(material4);
        thoseMaterials.Add(material5);
        thoseMaterials.Add(material6);
        return thoseMaterials;
    }
}
