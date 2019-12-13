using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PrototypeController : MonoBehaviour
{

    [SerializeField]
    AstroLanceInput controls;

    void Awake()
    {

        controls = new AstroLanceInput();

    }


}
