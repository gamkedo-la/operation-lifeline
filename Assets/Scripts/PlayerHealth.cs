﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
	[SerializeField] private Light pointLight;
	[SerializeField] private Light[] headLights;
	[Range(1,100)] private int health = 100;
	public float regenPerSec = 5f;
	public bool regenerating = true;
	float lightIntensity = 0;
	Color lightColor = Color.white;
	public GameObject particle;
	public Transform lifeLine;
	private MeshRenderer lifeLineMesh;
	float lifeLineLength;
	Color lifeLineColor;
	bool isDead = false;
	float regen = 0f;

	private void Start()
	{
		if (lifeLine)
		{
			lifeLineLength = lifeLine.localScale.y;
			lifeLineMesh = lifeLine.GetComponent<MeshRenderer>();
			lifeLineColor = lifeLineMesh.sharedMaterial.color;
		}
		if (pointLight) 
		{
			lightColor = pointLight.color;
			lightIntensity = pointLight.intensity;
		}
	}

	public void Update()
	{
		if (health<100 && regenerating &&!isDead) { Regenerate(); }
	}

	public void AdjustHealth(int adjustment)
	{
		health = health + adjustment;
		AdjustHealthIndicators();
	}

	private void Regenerate()
	{
		regen += regenPerSec * Time.deltaTime;
		if (regen >= 1f) 
		{ 
			health = health + 1; 
			regen = regen - 1f; 
		}
	}

	public void TakeDamage(int damage)
	{
		AdjustHealth(-damage);
		if (health<1 && !isDead) { Die(); }
	}

	private void AdjustHealthIndicators()
	{
		float healthPercent = (float)health / 100f;
		if (lifeLine)
		{
			lifeLine.localScale = new Vector3(lifeLine.localScale.x,
												lifeLineLength * healthPercent,
												lifeLine.localScale.z);
			Color newColor = new Color(lifeLineColor.r * (2 - healthPercent),
									   lifeLineColor.g * healthPercent,
									   lifeLineColor.b * healthPercent);
			lifeLineMesh.sharedMaterial.color = newColor;
			lifeLineMesh.material.color = newColor;
		}
		if (pointLight)
		{
			pointLight.intensity = lightIntensity * healthPercent;
			pointLight.color = new Color(lightColor.r, 
										 lightColor.g * healthPercent, 
										 lightColor.b);
		}
		if (headLights.Length>0)
		{
			if (health<50) 
			{
				if (headLights[0]) { headLights[0].enabled = true; }
				if (headLights[1]) { headLights[1].enabled = true; }
			}
			else
			{
				if (headLights[0]) { headLights[0].enabled = false; }
				if (headLights[1]) { headLights[1].enabled = false; }
			}
		}
	}

	public void Die()
	{
		isDead = true;
		foreach (Transform child in transform)
		{
			if (child.gameObject.tag=="Wreckage") { child.SetParent(null); }
		}
		GameObject deathParticle = Instantiate(particle, transform.position, Quaternion.Euler(0f, 180f, 0f));
		deathParticle.GetComponent<ParticleSystem>().Play();
		Destroy(this.gameObject, 0.2f);
	}
}
