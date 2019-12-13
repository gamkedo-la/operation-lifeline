using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Thruster { Left, Right}

public static class PlayerInput
{
	private static KeyCode rightThrustButton = KeyCode.RightShift;
	private static KeyCode leftThrustButton = KeyCode.LeftControl;
	private static bool rightThrusterActive = false;
	private static bool leftThrusterActive = false;
	public static bool RightThrust { get { return rightThrusterActive; } }
	public static bool LeftThrust { get { return leftThrusterActive; } }

	public static void CheckInput()
	{
		/////////////////
        // RIGHT THRUSTER
        if (Input.GetKey(rightThrustButton)
            
            // alternate keys allowed, so it "just works" as players guess it should
            || Input.GetKey(KeyCode.RightControl) // some macs do not have one?!
            || Input.GetKey(KeyCode.Return) // for symmetry w capslock
            // just for fun, the entire keyboard split in two
            || Input.GetKey(KeyCode.Y) || Input.GetKey(KeyCode.U) || Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.O) || Input.GetKey(KeyCode.P)
            || Input.GetKey(KeyCode.H) || Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.Semicolon)
            || Input.GetKey(KeyCode.B) || Input.GetKey(KeyCode.N) || Input.GetKey(KeyCode.M) || Input.GetKey(KeyCode.Comma) || Input.GetKey(KeyCode.Period) || Input.GetKey(KeyCode.Slash)

        ) { 
            rightThrusterActive = true; 
        }
		else { 
            rightThrusterActive = false; 
        }

		/////////////////
        // LEFT THRUSTER
		if (Input.GetKey(leftThrustButton)

            // alternate keys allowed, so it "just works" as players guess it should
            || Input.GetKey(KeyCode.LeftShift) // for symmetry w left
            || Input.GetKey(KeyCode.CapsLock) // for symmetry w return
            // just for fun, the entire keyboard split in two
            || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.T)
            || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.G)
            || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.V)

        ) {
            leftThrusterActive = true; 
        }
		else { 
            leftThrusterActive = false; 
        }
	}

	public static void AssignKey(Thruster thruster, KeyCode newKey)
	{
		if (thruster == Thruster.Right) { rightThrustButton = newKey; } 
		else if (thruster == Thruster.Left) { leftThrustButton = newKey; }
	}
}
