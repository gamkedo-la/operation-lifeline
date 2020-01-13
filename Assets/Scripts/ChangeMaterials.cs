using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterials : MonoBehaviour
{

    [SerializeField]
    private MeshRenderer modelMeshRenderer;

    [SerializeField]
    public Material[] materials;

    public int materialIndex = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

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
