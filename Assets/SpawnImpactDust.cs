using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnImpactDust : MonoBehaviour
{
	[SerializeField] ParticleSystem impactEffect;
	private bool shouldBePlaying = false;

	private void Awake()
	{
		impactEffect.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (shouldBePlaying && impactEffect.isStopped)
		{
			shouldBePlaying = false;
			impactEffect.Stop();
			impactEffect.gameObject.SetActive(false);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		impactEffect.gameObject.SetActive(true);
		impactEffect.transform.position = collision.GetContact(0).point;
		impactEffect.transform.LookAt(collision.collider.transform);
		shouldBePlaying = true;
		impactEffect.Play();
	}
}
