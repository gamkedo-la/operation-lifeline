using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{

    bool leftEngineOn = false;
    bool rightEngineOn = false;

    private AstroLanceInput astroLanceInput;    

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
/*
    private void OnEnable()
    {
        astroLanceInput.PlayerActionMap.LeftEngineOn.performed += LeftEngineCalled;
        astroLanceInput.PlayerActionMap.LeftEngineOn.Enable();

        astroLanceInput.PlayerActionMap.RightEngineOn.performed += RightEngineCalled;
        astroLanceInput.PlayerActionMap.RightEngineOn.Enable();
    }

    private void OnDisable()
    {
        astroLanceInput.PlayerActionMap.LeftEngineOn.Disable();
        astroLanceInput.PlayerActionMap.RightEngineOn.Disable();

    }
    */
    public void LeftEngineCalled(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
        leftEngineOn = value >= 0.9f;
    }

    public void RightEngineCalled(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
        rightEngineOn = value >= 0.9f;
    }

    private void Awake()
    {
        astroLanceInput = new AstroLanceInput();
    }

    void Start()
    {
        constantForce2D = GetComponent<ConstantForce2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbodyConstraints2D = new RigidbodyConstraints2D();
    }


    void FixedUpdate()
    {
        //PlayerInput.CheckInput();

        if (!GameManager.Instance.IsPaused)
        {
            if (rigidbody2D.constraints != RigidbodyConstraints2D.None)
            {
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
            if (leftEngineOn && leftThrusterFunctional)
            {
                currentTorque += leftPlayerTorque;
                currentThrust += thrust;
            }
            else if (!leftThrusterFunctional) { rigidbody2D.angularVelocity = 0f; }
            if (rightEngineOn && rightThrusterFunctional)
            {
                currentTorque += rightPlayerTorque;
                currentThrust += thrust;
            }
            else if (!rightThrusterFunctional) { rigidbody2D.angularVelocity = 0f; }
            
            constantForce2D.relativeForce = transform.InverseTransformDirection(transform.up * currentThrust);
            constantForce2D.torque = currentTorque;
            //SetThrusters(PlayerInput.LeftThrust && leftThrusterFunctional, PlayerInput.RightThrust && rightThrusterFunctional);
            SetThrusters(leftEngineOn, rightEngineOn);

            savedRelativeForce = constantForce2D.relativeForce;
            savedTorque = constantForce2D.torque;
            savedVelocity = rigidbody2D.velocity;
            savedAnguarVelocity = rigidbody2D.angularVelocity;
        }
        else
        {
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void SetThrusters(bool leftPlayerThrusting, bool rightPlayerThrusting)
    {
        if (playerEffects)
        {
            playerEffects.SetThrusters(leftPlayerThrusting, rightPlayerThrusting);
        }
    }

}
