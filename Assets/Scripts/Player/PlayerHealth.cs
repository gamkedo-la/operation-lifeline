using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
	[Range(1,100)] private int health = 100;
	[Range(0, 100)] [SerializeField] private int maxRengeration = 75;
	public float regenPerSec = 5f;
	public bool regenerating = true;
	public GameObject deathParticlePrefab;
	public Transform lifeLine;
	private MeshRenderer lifeLineMesh;
	float lifeLineLength;
	Color lifeLineColor;
	bool isDead = false;
	float regen = 0f;

    private GameObject gameOverCanvas;
    private GameOverText gameOverScript;
    [SerializeField]
    

	private FMOD.Studio.EventInstance impactAudio;

	private void Start()
	{
		if (lifeLine)
		{
			lifeLineLength = lifeLine.localScale.y;
			lifeLineMesh = lifeLine.GetComponent<MeshRenderer>();
			lifeLineColor = lifeLineMesh.sharedMaterial.color;
		}

        gameOverCanvas = GameObject.Find("GameOverCanvas");
        gameOverScript = gameOverCanvas.GetComponent<GameOverText>();

	}

	public void Update()
	{
		if (health<maxRengeration && regenerating && !isDead) { Regenerate(); }
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
			AdjustHealth(1);
			regen = regen - 1f; 
		}
	}

	public void TakeDamage(int damage)
	{
		AdjustHealth(-damage);
		FMODUnity.RuntimeManager.PlayOneShot("event:/Main/Player/Impact");
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
			//Color newColor = new Color(lifeLineColor.r * (2 - healthPercent),
			//						   lifeLineColor.g * healthPercent,
			//						   lifeLineColor.b * healthPercent);
			//lifeLineMesh.sharedMaterial.color = newColor;
			//lifeLineMesh.material.color = newColor;
		}
	}

	public void Die()
	{
		isDead = true;
		foreach (Transform child in transform)
		{
			if (child.gameObject.tag=="Wreckage") { child.SetParent(null); }
		}
		GameObject deathParticle = Instantiate(deathParticlePrefab, transform.position, Quaternion.Euler(0f, 180f, 0f));
		deathParticle.GetComponent<ParticleSystem>().Play();
		Destroy(this.gameObject, 0.2f);
        gameOverScript.ActivateAnimatorOnShipDestruction();
	}
}
