using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPaintJob : MonoBehaviour
{

    private static CurrentPaintJob _instance;

    public static CurrentPaintJob Instance { get; }

    public Material paintJob;

    public ChangeMaterials changeMaterials;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance.gameObject);
        }
        else
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }

        changeMaterials = FindObjectOfType<ChangeMaterials>();

    }

    private void Update()
    {
        if (changeMaterials != null)
        {
            paintJob = changeMaterials.materials[changeMaterials.materialIndex];
        }
    }
}
