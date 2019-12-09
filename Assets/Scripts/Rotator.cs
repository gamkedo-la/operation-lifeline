using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	[SerializeField] private bool rotating = true;
	[SerializeField] private float rotationSpeed = 1f;

	void Update()
    {
		if (rotating) { Rotate(rotationSpeed * Time.deltaTime); }
    }

	private void Rotate(float rotSpeed)
	{
		transform.Rotate(Vector3.up, Space.Self);
	}
}
