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

	Vector2 savedRelativeForce = Vector2.zero;
	float savedTorque = 0;
	Vector2 savedVelocity = Vector2.zero;
	float savedAnguarVelocity = 0;

	Rigidbody2D rigidbody2D;
	RigidbodyConstraints2D rigidbodyConstraints2D;
	[SerializeField] private PlayerEffects playerEffects;

	private FMOD.Studio.EventInstance thrustAudio;

	void Start()
    {
        constantForce2D = GetComponent<ConstantForce2D>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		rigidbodyConstraints2D = new RigidbodyConstraints2D();
		thrustAudio = FMODUnity.RuntimeManager.CreateInstance("event:/Main/Player/Thrust");
		thrustAudio.start();
	}

	void OnDestroy() 
	{
		thrustAudio.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		thrustAudio.release();
	}

	void FixedUpdate()
    {
		PlayerInput.CheckInput();

		if (!GameManager.Instance.IsPaused) {
			if (rigidbody2D.constraints != RigidbodyConstraints2D.None) {
				constantForce2D.relativeForce = savedRelativeForce;
				constantForce2D.torque = savedTorque;
				rigidbody2D.velocity = savedVelocity;
				rigidbody2D.angularVelocity = savedAnguarVelocity;
			}

			rigidbody2D.constraints = RigidbodyConstraints2D.None;

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
			
			constantForce2D.relativeForce = transform.InverseTransformDirection(transform.up * currentThrust);
			constantForce2D.torque = currentTorque;
			//SetThrusters(PlayerInput.LeftThrust && leftThrusterFunctional, PlayerInput.RightThrust && rightThrusterFunctional);
			SetThrusters(PlayerInput.LeftThrust, PlayerInput.RightThrust);

			savedRelativeForce = constantForce2D.relativeForce;
			savedTorque = constantForce2D.torque;
			savedVelocity = rigidbody2D.velocity;
			savedAnguarVelocity = rigidbody2D.angularVelocity;
		}
		else {
			rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;			
		}
	}

	private void SetThrusters(bool leftPlayerThrusting, bool rightPlayerThrusting)
	{
		if (leftPlayerThrusting && rightPlayerThrusting) 
		{
			thrustAudio.setParameterByName("Number of thrusters", 2);
		} 
		else if (leftPlayerThrusting || rightPlayerThrusting) 
		{
			thrustAudio.setParameterByName("Number of thrusters", 1);
		} 
		else if (!leftPlayerThrusting && !rightPlayerThrusting) 
		{
			thrustAudio.setParameterByName("Number of thrusters", 0);
		}

		if (playerEffects)
		{
			playerEffects.SetThrusters(leftPlayerThrusting, rightPlayerThrusting);
		}
	}
}
