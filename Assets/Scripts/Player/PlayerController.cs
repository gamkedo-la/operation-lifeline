using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private enum FlightMode { Newtonian, Direct }
	[SerializeField] private FlightMode flightMode = FlightMode.Direct;
    public float thrust = 10f;
    public float leftPlayerTorque = -0.5f;
    public float rightPlayerTorque = 0.5f;
	ConstantForce2D constantForce2D;
	enum Thrusting { None, Both, Right, Left }
	Thrusting prevThrusting = Thrusting.None;

	private bool rightThrusterDisabledByExternal = false;
	private bool leftThrusterDisabledByExternal = false;

	Vector2 savedRelativeForce = Vector2.zero;
	float savedTorque = 0;
	Vector2 savedVelocity = Vector2.zero;
	float savedAnguarVelocity = 0;
	float turnChangeHandlingBoost = 40f;
	float thrusterEnhancementMultiplier = 1.8f;
	float maxAngularVelocity = 75f;

	Rigidbody2D rbody2D;
	RigidbodyConstraints2D unfrozenConstraints;
	Vector2 unfrozenVelocity;
	float unfrozenAngularVelocity;
	bool unfrozenKinematic;
	bool unfrozenSimulated;

	//RigidbodyConstraints2D rbodyConstraints2D = rbody2D;
	[SerializeField] private PlayerEffects playerEffects = null;
	[SerializeField] private bool stableHandlingMode = true;
	[SerializeField] private bool enhancedBoosters = true;
	[SerializeField] private bool enhancedMainDrive = true;
	[SerializeField] private bool invertedControls = false;
	private FMOD.Studio.EventInstance thrustAudio;
	private bool timersFrozen = false;

	void Start()
    {
        constantForce2D = GetComponent<ConstantForce2D>();
		rbody2D = GetComponent<Rigidbody2D>();
		//rbodyConstraints2D = new RigidbodyConstraints2D();
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
			if (rbody2D.constraints != RigidbodyConstraints2D.None) {
				constantForce2D.relativeForce = savedRelativeForce;
				constantForce2D.torque = savedTorque;
				rbody2D.velocity = savedVelocity;
				rbody2D.angularVelocity = savedAnguarVelocity;
			}

			rbody2D.constraints = RigidbodyConstraints2D.None;

			float currentTorque = 0f;
			float currentThrust = 0;
			if (enhancedMainDrive) { currentThrust = thrust * 0.5f * thrusterEnhancementMultiplier; }
			else { currentThrust = thrust * 0.5f; }

			bool leftThrusterFunctional = (flightMode != FlightMode.Direct || rbody2D.rotation > -60f || rbody2D.rotation > 300f);
			bool rightThrusterFunctional = (flightMode != FlightMode.Direct || rbody2D.rotation < 60f || rbody2D.rotation < -300f);
			
			bool leftThrusting = false;
			bool rightThrusting = false;
			if (invertedControls) 
			{
				leftThrusting = PlayerInput.RightThrust && leftThrusterFunctional;
				rightThrusting = PlayerInput.LeftThrust && rightThrusterFunctional;
			}
			else 
			{
				leftThrusting = PlayerInput.LeftThrust && leftThrusterFunctional;
				rightThrusting = PlayerInput.RightThrust && rightThrusterFunctional;
			}

			if (leftThrusterDisabledByExternal) 
			{ 
				leftThrusterFunctional = false;
				leftThrusting = false;
			}
			if (rightThrusterDisabledByExternal) 
			{ 
				rightThrusterFunctional = false;
				rightThrusting = false;
			}

			bool bothThrusting = leftThrusting && rightThrusting;

			if (leftThrusting && !bothThrusting) 
			{
				if (stableHandlingMode && prevThrusting != Thrusting.Left) 
				{ 
					rbody2D.angularVelocity = 0f;
					currentTorque += leftPlayerTorque * turnChangeHandlingBoost;
					prevThrusting = Thrusting.Left; 
				}
				currentTorque += leftPlayerTorque;
				if (enhancedBoosters)
				{
					currentThrust += (thrust * thrusterEnhancementMultiplier);
				}
				else { currentThrust += thrust; }
			}
			else if (!leftThrusterFunctional) 
			{
				//rbody2D.angularVelocity = 0f;
				rbody2D.rotation = Mathf.Clamp(rbody2D.rotation, -60f, 60f);
				if (leftThrusting && stableHandlingMode) { currentTorque = 0f; constantForce2D.torque = 0f; }
			}

			if (rightThrusting && !bothThrusting) 
			{
				if (stableHandlingMode && prevThrusting != Thrusting.Right)
				{
					rbody2D.angularVelocity = 0f;
					currentTorque += rightPlayerTorque * turnChangeHandlingBoost;
					prevThrusting = Thrusting.Right;
				}
				currentTorque += rightPlayerTorque;
				if (enhancedBoosters)
				{
					currentThrust += (thrust * thrusterEnhancementMultiplier);
				}
				else { currentThrust += thrust; }
			}
			else if (!rightThrusterFunctional) 
			{
				//rbody2D.angularVelocity = 0f; 
				rbody2D.rotation = Mathf.Clamp(rbody2D.rotation, -60f, 60f);
				if (rightThrusting && stableHandlingMode) { currentTorque = 0f; constantForce2D.torque = 0f; }
			}

			if (bothThrusting)
			{
				if (stableHandlingMode && prevThrusting != Thrusting.Both)
				{
					rbody2D.angularVelocity = 0f;
					currentTorque = 0f;
					prevThrusting = Thrusting.Both;
				}
				currentTorque = 0f;
				if (enhancedBoosters)
				{
					currentThrust += (thrust * thrusterEnhancementMultiplier);
					currentThrust += (thrust * thrusterEnhancementMultiplier);
					currentThrust += thrust;
				}
				else { currentThrust += thrust; }
			}
			
			if (!rightThrusting && !leftThrusting) 
			{
				if (stableHandlingMode)
				{
					rbody2D.angularVelocity = 0f;
					currentTorque = 0f;
					prevThrusting = Thrusting.None;
				}
			}

			constantForce2D.relativeForce = transform.InverseTransformDirection(transform.up * currentThrust);
			constantForce2D.torque = currentTorque;
			if (stableHandlingMode)
			{
				rbody2D.angularVelocity = Mathf.Clamp(rbody2D.angularVelocity, -maxAngularVelocity, maxAngularVelocity);
			}
			
			
			//SetThrusters(PlayerInput.LeftThrust && leftThrusterFunctional, PlayerInput.RightThrust && rightThrusterFunctional);
			if (invertedControls)
			{
				SetThrusters(PlayerInput.RightThrust, PlayerInput.LeftThrust);
			}
			else 
			{
				SetThrusters(PlayerInput.LeftThrust, PlayerInput.RightThrust);
			}
			

			savedRelativeForce = constantForce2D.relativeForce;
			savedTorque = constantForce2D.torque;
			savedVelocity = rbody2D.velocity;
			savedAnguarVelocity = rbody2D.angularVelocity;
		}
		else {
			rbody2D.constraints = RigidbodyConstraints2D.FreezeAll;			
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

	public void ActivateDockingProtocol()
	{
		DisableRightThrusterByExternal();
		DisableLeftThrusterByExternal();
		DisableTimers();
	}

	public void DisableRightThrusterByExternal()
	{
		rightThrusterDisabledByExternal = true;
	}

	public void DisableLeftThrusterByExternal()
	{
		leftThrusterDisabledByExternal = true;
	}

	public void RepairThrusters()
	{
		rightThrusterDisabledByExternal = false;
		leftThrusterDisabledByExternal = false;
		DisableTimers();
	}

	public void DisableTimers()
	{
		timersFrozen = true;
	}

	public void EnableTimers()
	{
		timersFrozen = false;
	}

	public bool AreTimersFrozen()
	{
		return timersFrozen;
	}

	public void PatientDeath()
	{
		ActivateDockingProtocol();
		Freeze();
		GameObject gameOverCanvas = GameObject.Find("GameOverCanvas");
		if (gameOverCanvas) 
		{
			GameOverText gameOverScript = gameOverCanvas.GetComponent<GameOverText>();
			if (gameOverScript) { gameOverScript.ActivateAnimatorOnPatientDeath(); }
		}
	}

	public void Freeze()
	{
		unfrozenConstraints = rbody2D.constraints;
		unfrozenVelocity = rbody2D.velocity;
		unfrozenAngularVelocity = rbody2D.angularVelocity;
		unfrozenKinematic = rbody2D.isKinematic;
		unfrozenSimulated = rbody2D.simulated;

		rbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
		rbody2D.velocity = Vector2.zero;
		rbody2D.angularVelocity = 0f;
		rbody2D.isKinematic = true;
		rbody2D.simulated = false;
	}

	public void UnFreeze()
	{
		rbody2D.constraints = unfrozenConstraints;
		rbody2D.velocity = unfrozenVelocity;
		rbody2D.angularVelocity = unfrozenAngularVelocity;
		rbody2D.isKinematic = unfrozenKinematic;
		rbody2D.simulated = unfrozenSimulated;
	}
}
