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
		if (Input.GetKey(rightThrustButton)) { rightThrusterActive = true; }
		else { rightThrusterActive = false; }
		if (Input.GetKey(leftThrustButton)) { leftThrusterActive = true; }
		else { leftThrusterActive = false; }
	}

	public static void AssignKey(Thruster thruster, KeyCode newKey)
	{
		if (thruster == Thruster.Right) { rightThrustButton = newKey; } 
		else if (thruster == Thruster.Left) { leftThrustButton = newKey; }
	}
}
