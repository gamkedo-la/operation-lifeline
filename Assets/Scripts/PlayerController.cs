using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrust = 10f;
    public float leftPlayerTorque = -1f;
    public float rightPlayerTorque = 1f;
	ConstantForce2D constantForce2D;
	[SerializeField] private PlayerEffects playerEffects;

	void Start()
    {
        constantForce2D = GetComponent<ConstantForce2D>();
	}

  
    void FixedUpdate()
    {
		PlayerInput.CheckInput();
		float currentThrust = 0f;
		float currentTorque = 0f;
		if (PlayerInput.LeftThrust) 
		{
			currentTorque += leftPlayerTorque;
			currentThrust += thrust;
		}
		if (PlayerInput.RightThrust) 
		{
			currentTorque += rightPlayerTorque;
			currentThrust += thrust; 
		}

		constantForce2D.relativeForce = new Vector2(0f, currentThrust);
		constantForce2D.torque = currentTorque;
		SetThrusters(PlayerInput.LeftThrust, PlayerInput.RightThrust);
    }

	private void SetThrusters(bool leftPlayerThrusting, bool rightPlayerThrusting)
	{
		if (playerEffects)
		{
			playerEffects.SetThrusters(leftPlayerThrusting, rightPlayerThrusting);
		}
	}
}
