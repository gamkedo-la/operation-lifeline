using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : Collectibles, ICollectable
{
    public GameObject shieldPrefab;
	[Range(1,50)][SerializeField] private int shieldHealth = 20;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			base.PlayerCollision(this);
		}
	}

	public void ResolvePickupEffect(PlayerController controller)
	{
		controller.PowerUpShield(shieldPrefab, shieldHealth, this);
	}

	public void ResolvePickedUp()
	{
		base.ResolvePickedUp(this.gameObject);
	}
}
