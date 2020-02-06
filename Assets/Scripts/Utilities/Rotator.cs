using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	[SerializeField] private bool rotating = true;
	[SerializeField] private bool weightedToward0 = true;
	[SerializeField] private float minRrotationSpeed = -3f;
	[SerializeField] private float maxRrotationSpeed = 3f;
    [SerializeField] private enum RotationDirection { left, right, up, random, forward};
    [SerializeField] RotationDirection rotationDirection = RotationDirection.up;
	private float rotationSpeed = 0f;

	private void Start()
	{
		rotationSpeed = Random.Range(minRrotationSpeed, maxRrotationSpeed);
		if (weightedToward0 && Random.Range(0,100)<50) { rotationSpeed = rotationSpeed * 0.5f; }
	}
	void Update()
    {
		if (rotating) { Rotate(rotationSpeed); }
    }

	private void Rotate(float rotSpeed)
	{
		if (rotationDirection == RotationDirection.random)
		{
			rotationDirection = (RotationDirection)Random.Range(0, 2);
		}

        if(rotationDirection == RotationDirection.up)
        {
            transform.Rotate(Vector3.up * rotSpeed, Space.Self);
        }
        if (rotationDirection == RotationDirection.left)
        {
            transform.Rotate(Vector3.left * rotSpeed, Space.Self);
        }
        if (rotationDirection == RotationDirection.right)
        {
            transform.Rotate(Vector3.right * rotSpeed, Space.Self);
        }
		if (rotationDirection == RotationDirection.forward)
		{
			transform.Rotate(Vector3.forward * rotSpeed, Space.World);
		}
        else
        {
            return;
        }
    }
}
