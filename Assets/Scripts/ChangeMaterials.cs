using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterials : MonoBehaviour
{

    private static ChangeMaterials _instance;
    public static ChangeMaterials Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ChangeMaterials>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    [SerializeField]
    private MeshRenderer modelMeshRenderer;

    [SerializeField]
    public Material[] materials;

    public int materialIndex = 0;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(gameObject);
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
