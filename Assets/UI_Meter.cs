using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Meter : MonoBehaviour
{
	Transform player;
	[SerializeField] Image border;
	[SerializeField] Transform destination;
	[SerializeField] float startingTimeUntilDeath = 100f;
	float startingDistance;
	[SerializeField] float arrivalDistance = 2.8f;
	float timeUntilDeath;
	float currentDistance;
	float percentETA;
	float percentETD;
	[SerializeField] Image knobETA;
	[SerializeField] Image knobETD;
	Vector3 rotationETA;
	Vector3 rotationETD;
	Rigidbody2D rb;
	float timeUntilArrival;
	float vel;
	float minVelValue = 1f;
	[SerializeField] Slider speedIndicator;
	[SerializeField] Image speedFillBar;
	[SerializeField] Text textETD;

    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = player.gameObject.GetComponent<Rigidbody2D>();
		vel = Mathf.Clamp(rb.velocity.y, minVelValue, Mathf.Infinity);
		timeUntilDeath = startingTimeUntilDeath;
		percentETD = timeUntilDeath / startingTimeUntilDeath;
		startingDistance = DetermineDistance();
		currentDistance = startingDistance;
		timeUntilArrival = Mathf.Clamp(currentDistance / vel, 0f, startingTimeUntilDeath);
		percentETA = timeUntilArrival / startingTimeUntilDeath;
	}

	private float DetermineDistance()
	{
		if (!player) { return Mathf.Infinity; }
		var distance = Vector3.Distance(player.position, destination.position);
		if (distance > arrivalDistance) { distance = distance - arrivalDistance; } else { distance = 0f; }
		return distance;
	}    

    void Update()
    {
		if (!player) { return; }
		timeUntilDeath = Mathf.Clamp(timeUntilDeath - Time.deltaTime, 0f, startingTimeUntilDeath);
		if (textETD) { textETD.text = timeUntilDeath.ToString(); }
		percentETD = timeUntilDeath / startingTimeUntilDeath;
		rotationETD = -Vector3.forward * (270f * percentETD);
		knobETD.transform.rotation = Quaternion.Euler(rotationETD);

		currentDistance = DetermineDistance();
		vel = Mathf.Clamp(rb.velocity.y, minVelValue, Mathf.Infinity);
		speedIndicator.value = (vel - minVelValue) / 400f;
		timeUntilArrival = Mathf.Clamp(currentDistance / vel, 0f, startingTimeUntilDeath);
		percentETA = timeUntilArrival / startingTimeUntilDeath;
		rotationETA = -Vector3.forward * (270f * percentETA);
		knobETA.transform.rotation = Quaternion.Euler(rotationETA);
		
		if (timeUntilArrival < timeUntilDeath) 
		{ 
			border.color = Color.white;
			speedFillBar.color = Color.green;
		} 
		else 
		{ 
			border.color = Color.red;
			speedFillBar.color = Color.red;
		}
	}
}
