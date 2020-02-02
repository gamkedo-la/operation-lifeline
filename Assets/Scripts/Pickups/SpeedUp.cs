using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Collectibles, ICollectable

{
	[SerializeField] public float duration = 2.5f;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			base.PlayerCollision(this);
		}
	}

	public void ResolvePickupEffect(PlayerController controller)
	{
		controller.PowerUpSpeed(duration, this);
	}

	public void ResolvePickedUp()
	{
		base.ResolvePickedUp(this.gameObject);
	}
}
