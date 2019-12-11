using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
	public float flickerVariance = .05f;
	private Vector3 basePosition = Vector3.zero;
	private Vector3 displacedPosition = Vector3.zero;

	private void Start()
	{
		basePosition = transform.localPosition;
	}
	// Update is called once per frame
	void Update()
    {
		displacedPosition = basePosition + (transform.up * Random.Range(-flickerVariance, flickerVariance));
		transform.localPosition = displacedPosition;  
    }
}
