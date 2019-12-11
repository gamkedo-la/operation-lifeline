using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private enum FlightMode { Newtonian, Direct }
	[SerializeField] private FlightMode flightMode;
    public float thrust = 10f;
    public float leftPlayerTorque = -1f;
    public float rightPlayerTorque = 1f;
	ConstantForce2D constantForce2D;
	Rigidbody2D rigidbody2D;
	RigidbodyConstraints2D rigidbodyConstraints2D;
	[SerializeField] private PlayerEffects playerEffects;

	void Start()
    {
        constantForce2D = GetComponent<ConstantForce2D>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		rigidbodyConstraints2D = new RigidbodyConstraints2D();
	}

  
    void FixedUpdate()
    {
		PlayerInput.CheckInput();
		float currentThrust = thrust * 0.5f;
		float currentTorque = 0f;
		bool leftThrusterFunctional = (flightMode != FlightMode.Direct || rigidbody2D.rotation > -60f || rigidbody2D.rotation > 300f);
		bool rightThrusterFunctional = (flightMode != FlightMode.Direct || rigidbody2D.rotation < 60f || rigidbody2D.rotation < -300f);
		if (PlayerInput.LeftThrust && leftThrusterFunctional) 
		{
			currentTorque += leftPlayerTorque;
			currentThrust += thrust;
		}
		else if (!leftThrusterFunctional) { rigidbody2D.angularVelocity = 0f; }
		if (PlayerInput.RightThrust && rightThrusterFunctional) 
		{
			currentTorque += rightPlayerTorque;
			currentThrust += thrust; 
		}
		else if (!rightThrusterFunctional) { rigidbody2D.angularVelocity = 0f; }
		constantForce2D.relativeForce = new Vector2(0f, currentThrust);
		constantForce2D.torque = currentTorque;
		//SetThrusters(PlayerInput.LeftThrust && leftThrusterFunctional, PlayerInput.RightThrust && rightThrusterFunctional);
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
