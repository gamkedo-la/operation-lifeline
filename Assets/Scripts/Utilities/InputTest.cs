using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{


    public void LeftEngineCalled(InputAction.CallbackContext context)
    {

        Debug.Log("left engine called");
    }

   /* void FixedUpdate()
    {
        var keyboard = Keyboard.current;
        if(keyboard == null)
        {
            return;
        }

        if (keyboard.leftCtrlKey.wasPressedThisFrame)
        {
            Debug.Log("left engine fired");
        }
    }*/
}
