using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class RebingInputSceneController : MonoBehaviour
{
    public string sceneToLoad = "Main Scene";
    public Button startButton;
    public InputActionAsset astroLanceInputActionAsset;
    private InputActionMap playerActionMap;

    void Start()
    {
        playerActionMap = astroLanceInputActionAsset.FindActionMap("Player");
        playerActionMap.Disable();
        startButton.onClick.AddListener(StartButtonClicked);
    }

    private void StartButtonClicked()
    {
        playerActionMap.Enable();
        SceneManager.LoadScene(sceneToLoad);
    }
}
