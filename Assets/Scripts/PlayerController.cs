using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float thrust = 10f;

    public float player1Torque = -1f;
    public float player2Torque = 1f;
	public MeshRenderer player1Thruster;
	public MeshRenderer player2Thruster;
	public AudioSource thrusterSFX;
	[Range(0f,100f)] public float thrusterVolume = 50f;
	ConstantForce2D constantForce2D;
  


    // Use this for initialization
    void Awake()
    {
        constantForce2D = GetComponent<ConstantForce2D>();
		if (thrusterSFX) 
		{
			thrusterSFX.volume = 0f;
			thrusterSFX.Play();
		}
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (Input.GetMouseButton(0) && Input.GetMouseButton(1) == false)
        {
            constantForce2D.relativeForce = new Vector2(0f, thrust);
            constantForce2D.torque = player1Torque;
        }else if (Input.GetMouseButton(1) && Input.GetMouseButton(0) == false)
        {
            constantForce2D.relativeForce = new Vector2(0f, thrust);
            constantForce2D.torque = player2Torque;
        }else if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            constantForce2D.relativeForce = new Vector2(0f, thrust + thrust);
            constantForce2D.torque = 0f;
        }else if(Input.GetMouseButton(0) == false && Input.GetMouseButton(1) == false)
        {
            constantForce2D.relativeForce = new Vector2(0f, 0f);
            constantForce2D.torque = 0f;
        }*/


        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.RightShift) == false)
        {
            constantForce2D.relativeForce = new Vector2(0f, thrust);
            constantForce2D.torque = player1Torque;
			SetThrusters(true, false);
		}
        else if (Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.LeftControl) == false)
        {
            constantForce2D.relativeForce = new Vector2(0f, thrust);
            constantForce2D.torque = player2Torque;
			SetThrusters(false, true);
		}
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.RightShift))
        {
            constantForce2D.relativeForce = new Vector2(0f, thrust + thrust);
            constantForce2D.torque = 0f;
			SetThrusters(true, true);
		}
        else if ((Input.GetKey(KeyCode.LeftControl) == false && Input.GetKey(KeyCode.RightShift) == false))
        {
            constantForce2D.relativeForce = new Vector2(0f, 0f);
            constantForce2D.torque = 0f;
			SetThrusters(false, false);
		}
    }

	private void SetThrusters(bool plyrOneThrusting, bool plyrTwoThrusting)
	{
		if (player1Thruster) { player1Thruster.enabled = plyrOneThrusting; }
		if (player2Thruster) { player2Thruster.enabled = plyrTwoThrusting; }
		float engineBurn = 0f;
		if (plyrOneThrusting) { engineBurn = engineBurn + 0.5f; }
		if (plyrTwoThrusting) { engineBurn = engineBurn + 0.5f; }
		if (thrusterSFX)
		{
			thrusterSFX.volume = thrusterVolume * engineBurn / 100;
		}
	}
}
