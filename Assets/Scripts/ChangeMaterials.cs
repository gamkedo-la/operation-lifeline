using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterials : MonoBehaviour
{

    [SerializeField]
    private MeshRenderer modelMeshRenderer;

    [SerializeField]
    private Material[] materials;

    private int materialIndex = 0;

    public void RaiseMaterialIndex()
    {
        if(materialIndex < materials.Length)
        {
            materialIndex += 1;
        }
        else
        {
            materialIndex = 0;
        }
        ChangeMaterial();
    }
    public void LowerMaterialIndex()
    {
        if (materialIndex > 0)
        {
            materialIndex -= 1;
        }
        else
        {
            materialIndex = materials.Length;
        }
        ChangeMaterial();
    }


    public void ChangeMaterial()
    {
        modelMeshRenderer.material = materials[materialIndex];
    }
}
