using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	[SerializeField] private bool rotating = true;
	[SerializeField] private bool weightedToward0 = true;
	[SerializeField] private float minRrotationSpeed = -0.3f;
	[SerializeField] private float maxRrotationSpeed = 0.3f;
	private float rotationSpeed = 0f;

	private void Start()
	{
		rotationSpeed = Random.Range(minRrotationSpeed, maxRrotationSpeed);
		if (weightedToward0 && Random.Range(0,100)<50) { rotationSpeed = rotationSpeed * 0.5f; }
	}
	void Update()
    {
		if (rotating) { Rotate(rotationSpeed * Time.deltaTime); }
    }

	private void Rotate(float rotSpeed)
	{
		transform.Rotate(Vector3.up, Space.Self);
	}
}
