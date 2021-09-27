using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarUpholstery : MonoBehaviour
{
    public List<GameObject> upholsteryBodyWorkParts = new List<GameObject>();
    [SerializeField] List<UpholsteryMaterialSet> materialSet;

    private int currentMaterialIndex = 0;
    private int currentMaterialSetIndex = 0;
    private List<Material> currentMaterialSet = null;

    public void SetMaterialByIndex(int index)
    {
        if (materialSet.Count == 0)
        {
            Debug.LogWarning("Empty body Colour sets.");
            return;
        }

        if (index >= materialSet.Count)
        {
            Debug.LogError("Out of index.");
            return;
        }

        currentMaterialSet = materialSet[index].GetMaterialList();
        currentMaterialSetIndex = 0;

        foreach (Material mat in currentMaterialSet)
        {
            SetPartMaterial(currentMaterialSet);
            currentMaterialSetIndex++;
        }
    }

    int IsUpholsteryPaint(Material mat)
    {
        for(int i=0; i<materialSet.Count; i++)
        {
            List<Material> tmp = materialSet[i].GetMaterialList();
            for(int j=0; j<tmp.Count; j++)
            {
                if (tmp[j] == mat)
                    return j;
            }
        }
        return -1;
    }

    private void SetPartMaterial(List<Material> lMaterial)
    {
        if (upholsteryBodyWorkParts.Count == 0)
            return;

        foreach (GameObject bodyPart in upholsteryBodyWorkParts)
        {
            MeshRenderer[] lMeshRenderers = bodyPart.GetComponentsInChildren<MeshRenderer>();

            foreach (MeshRenderer lMeshRenderer in lMeshRenderers)
            {
                if (lMeshRenderer != null)
                {
                    Material[] lSharedMaterials = lMeshRenderer.sharedMaterials;
                    bool update = false;

                    for (int i = 0; i < lSharedMaterials.Length; i++)
                    {
                        int matIndex = IsUpholsteryPaint(lSharedMaterials[i]);
                        if (matIndex != -1)
                        {
                            lSharedMaterials[i] = currentMaterialSet[matIndex];
                            update = true;
                        }
                    }
                    if (update) lMeshRenderer.sharedMaterials = lSharedMaterials;
                }
            }
        }
    }
}
