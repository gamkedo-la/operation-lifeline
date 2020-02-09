using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class LoadMasterBank : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private string sceneToMoveTo;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager.LoadScene(sceneToMoveTo);
    }




}
