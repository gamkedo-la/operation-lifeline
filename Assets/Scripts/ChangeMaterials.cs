using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterials : MonoBehaviour
{

   /* private static ChangeMaterials _instance;
    public static ChangeMaterials Instance { get; }*/

    [SerializeField]
    private MeshRenderer modelMeshRenderer;

    [SerializeField]
    public Material[] materials;

    public int materialIndex = 0;

    [SerializeField]
    private CurrentPaintJob currentPaintJob;

    void Awake()
    {
        currentPaintJob = FindObjectOfType<CurrentPaintJob>();
        if (currentPaintJob.changeMaterials == null)
        {
            currentPaintJob.changeMaterials = this;
        }
    }

    public void RaiseMaterialIndex()
    {
        if(materialIndex == materials.Length-1)
        {
            materialIndex = 0;
        }
        else
        {
            materialIndex += 1;
        }
        ChangeMaterial();
    }
    public void LowerMaterialIndex()
    {
        if (materialIndex == 0)
        {
            materialIndex = materials.Length-1;
        }
        else
        {
            materialIndex -= 1;
        }
        ChangeMaterial();
    }


    public void ChangeMaterial()
    {


        modelMeshRenderer.material = materials[materialIndex];
    }
}
