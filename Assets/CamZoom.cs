using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoom : MonoBehaviour
{
	[SerializeField] private Rigidbody2D targetRigidbody;
	private float zoomSpeed = 50f;
	private float zoomPercent;
	private float velSq;
	private float maxVelSq = 62500*1.5f;
	private float minVelSq = 36250*1.5f;
	private float targetSize;
	private float currentSize;
	private Camera cam;
	private float baseSize;
	private void Start()
	{
		cam = this.GetComponent<Camera>();
		baseSize = cam.orthographicSize;
		targetSize = baseSize;
		currentSize = baseSize;
	}
	void LateUpdate()
	{
		if (targetRigidbody && cam)
		{
			velSq = Mathf.Clamp(targetRigidbody.velocity.sqrMagnitude, minVelSq, maxVelSq);
			zoomPercent = velSq*1.5f / maxVelSq;
			targetSize = zoomPercent * baseSize;

			currentSize = cam.orthographicSize;
			if (targetSize < currentSize && Mathf.Abs(currentSize - targetSize) > 1f)
			{
				cam.orthographicSize = currentSize - (zoomSpeed * Time.deltaTime);
			}
			else if (targetSize > currentSize && Mathf.Abs(currentSize - targetSize) > 1f)
			{
				cam.orthographicSize = currentSize + (zoomSpeed * Time.deltaTime);
			}
		}
	}
}
