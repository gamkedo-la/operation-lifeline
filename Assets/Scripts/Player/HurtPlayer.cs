using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
	[Range(0,100)]public int damageOnImpact = 10;
	[Range(0, 100)] public int damageOverTime = 0;		//damage per second
	public float hurtShakeDuration = 0.1f;
	public float hurtShakeAmount = 10f;
	public bool destroyedOnImpact = true;
	public GameObject particle;
	public float accumulatedDamage = 0f;

	private CameraController cameraController;
    private GameObject player;
    private PlayerShake playerShakeScript;	

    private void Awake()
    {
		cameraController = Camera.main.GetComponent<CameraController>();
        player = GameObject.Find("Player");
        playerShakeScript = player.GetComponent<PlayerShake>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
		if (damageOnImpact > 0)
		{
			InflictDamage(collision.collider, damageOnImpact);			
        }
		if (destroyedOnImpact) { Explode(); SelfDestruct(); }
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (damageOverTime > 0)
		{
			accumulatedDamage = accumulatedDamage + (Time.deltaTime * damageOverTime);
			if (accumulatedDamage > 1) 
			{
				int damageToInflict = (int)accumulatedDamage;
				accumulatedDamage = accumulatedDamage - damageToInflict;
				InflictDamage(other, damageToInflict);
			}
		}
	}

	private void OnTriggerExit2D()
	{
		accumulatedDamage = 0f;
	}

	private void InflictDamage(Collider2D other, int damageAmt)
	{
		IDamageable health = other.GetComponentInParent<IDamageable>();
		if (health != null) { health.TakeDamage(damageAmt); }

		if (health != null && 
			health.GetInvulnerability() == false &&
			playerShakeScript != null &&
			health.GetMaterialType() == MaterialType.Metal )
		{
			playerShakeScript.ShakeMe();
			if (cameraController) { cameraController.Shake(hurtShakeDuration, hurtShakeAmount); }
		}
				

	}

	private void Explode()
	{
		GameObject deathParticle = Instantiate(particle, transform.position, Quaternion.Euler(0f, 180f, 0f));
		deathParticle.GetComponent<ParticleSystem>().Play();
		Destroy(deathParticle, 1f);
	}

	public void SelfDestruct()
    {
		damageOnImpact = 0;
		Destroy(this.gameObject, 0.1f);     
    }


}
