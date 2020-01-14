﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPaintJob : MonoBehaviour
{
    private ChangeMaterials changeMaterials;

    [SerializeField]
    private MeshRenderer playerModel;

    void Awake()
    {
        changeMaterials = FindObjectOfType<ChangeMaterials>();

        playerModel.material = changeMaterials.materials[changeMaterials.materialIndex];
    }


}