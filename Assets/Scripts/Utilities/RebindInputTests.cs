using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class RebindInputTests : MonoBehaviour
{
    AstroLanceInput astroLanceInput;
    public Button button;
    public TextMeshProUGUI text;
    public InputActionReference astroLanceActionReference;

    private InputAction astroLanceInputAction;
    private InputAction astronLanceInputActionOff;
    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;


    void Awake()
    {        
        astroLanceInput = new AstroLanceInput();
        astroLanceInputAction = astroLanceActionReference.action;        

        button.onClick.AddListener(delegate { RemapButtonClicked(astroLanceInputAction); });
    }

    public void RemapLeftEngine()
    {                
        RemapButtonClicked(astroLanceInput.PlayerActionMap.LeftEngineOn);        
    }

    public void RemapButtonClicked(InputAction actionToRebind) 
    {
        button.enabled = false;
        text.text = "Press desired control button";
        rebindingOperation?.Dispose();

        rebindingOperation = astroLanceInputAction.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => ButtonRebindCompleted())
            .Start();           

    }

    private void ButtonRebindCompleted()
    {
        rebindingOperation.Dispose();
        rebindingOperation = null;
        ResetButtonMappingTextValue();
        button.enabled = true;
    }

    private void ResetButtonMappingTextValue()
    {
        text.text = InputControlPath.ToHumanReadableString(astroLanceInputAction.bindings[0].effectivePath);
    }
}
