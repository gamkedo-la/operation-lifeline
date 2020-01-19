using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCamController : MonoBehaviour
{
	private float speed = 0.04f;
	private Transform target;
	Vector3 updatedPos = Vector2.zero;
	Vector3 lastPosition = Vector2.zero;

	private void Start()
	{
		target = Camera.main.transform;
		lastPosition = target.position;
	}

	private void LateUpdate()
	{
		updatedPos = target.position - lastPosition;
		lastPosition = target.position;
		updatedPos *= speed;
		updatedPos += transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler(updatedPos);
	}
}
