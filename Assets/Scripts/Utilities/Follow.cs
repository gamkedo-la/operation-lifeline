using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
	[SerializeField] private Transform target;
	Vector3 newPosition = Vector3.zero;

	private void LateUpdate()
	{
		if (target) 
		{
			newPosition = target.position;
			newPosition.z = transform.position.z;
			transform.position = newPosition; 
		}
	}
}
