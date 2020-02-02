using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldHealth : MonoBehaviour, IDamageable
{
	[SerializeField]
	[Range(0f,10f)] private float drainPerSec = 1f;
	private int health = default;
	private int currentHealth = default;
	private PlayerController playerController = default;
	private float drain = default;
	private bool isInvulnerable = false;
	MaterialType materialType = MaterialType.Energy;
	Slider shieldBar = null;
	Image[] shieldBarImages = new Image[2];

	private void Start()
	{
		ResetCurrentHealth();
		shieldBarImages = shieldBar.GetComponentsInChildren<Image>();
	}

	private void Update()
	{
		RepositionShield();
		DrainShield();
		CheckHealth();
	}

	public MaterialType GetMaterialType()
	{
		return materialType;
	}

	private void RepositionShield()
	{
		if (playerController)
		{
			transform.position = playerController.transform.position;
		}
		else { Die(); }
	}

	private void CheckHealth()
	{
		if (currentHealth <= 0)
		{
			Die();
		}
		AdjustHealthIndicators();
	}

	public void Die()
	{
		currentHealth = 0;
		AdjustHealthIndicators();
		if (shieldBar) { RevealShieldBar(false); }
		if (playerController) { playerController.Invulnerable(false); }
		this.gameObject.SetActive(false);
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		CheckHealth();
	}

	public void ResetCurrentHealth()
	{
		currentHealth = health;
		CheckHealth();
	}

	public void ActivateShield(int health, Slider shieldBar, PlayerController playerController)
	{
		this.playerController = playerController;
		this.health = health;
		this.shieldBar = shieldBar;
		RepositionShield();
		ResetCurrentHealth();
		if (this.shieldBar) { RevealShieldBar(true); }
		AdjustHealthIndicators();
	}

	private void RevealShieldBar(bool toShow)
	{
		if (shieldBarImages.Length == 0) { return; }
		foreach (Image shieldBarImage in shieldBarImages)
		{
			if (shieldBarImage) 
			{
				shieldBarImage.enabled = toShow;
			}
			
		}
		AdjustHealthIndicators();
	}

	private void DrainShield()
	{
		if (health < 1) { return; }
		drain += (drainPerSec * Time.deltaTime);
		if (drain>=1f) 
		{
			drain -= 1f;
			currentHealth -= 1;
			CheckHealth();
		}
	}

	public void SetInvulnerability (bool isInvulnerable)
	{
		this.isInvulnerable = isInvulnerable;
	}

	public bool GetInvulnerability()
	{
		return isInvulnerable;
	}

	private void AdjustHealthIndicators()
	{
		float healthPercent = (float)currentHealth / health;
		if (shieldBar) { shieldBar.value = healthPercent; }
	}
}
