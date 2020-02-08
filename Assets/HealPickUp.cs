using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickUp : Collectibles, ICollectable
{
	private UI_Meter meters;
	[SerializeField] private float healthBonus = 5f; 

	protected override void Start()
    {
		base.Start();
		meters = FindObjectOfType<UI_Meter>();        
    }

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			base.PlayerCollision(this);
		}
	}

	public void ResolvePickedUp()
	{
		base.ResolvePickedUp(this.gameObject);
	}

	public void ResolvePickupEffect(PlayerController controller)
	{
		meters.timeUntilDeath += healthBonus;
	}

}
