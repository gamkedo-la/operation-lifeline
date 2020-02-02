using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
	protected GameObject player = default;
	protected PlayerController playerController = default;
	[SerializeField] protected GameObject particlesPrefab = default;

	protected virtual void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerController = player.GetComponent<PlayerController>();
	}

	protected void SpawnParticles()
	{
		GameManager.Instance.uiSoundOnHover(); 
		GameObject particlesGO = Instantiate(particlesPrefab, transform.position, Quaternion.identity);
	}

	protected void PlayerCollision(ICollectable collected)
	{
		if (!player) { player = GameObject.FindGameObjectWithTag("Player"); }
		if (player)
		{
			if (!playerController) { playerController = player.GetComponent<PlayerController>(); }
			if (playerController)
			{
				collected.ResolvePickupEffect(playerController);
				collected.ResolvePickedUp();
				
			}
			else { Debug.Log("Collectable Error: PlayerController not found"); }
		}
		else
		{
			Debug.Log("Collectable Error: player GameObject not found");
		}
	}



	public void ResolvePickedUp(GameObject concreteObject)
	{
		Instantiate(particlesPrefab, concreteObject.transform.position, Quaternion.identity);
		GameManager.Instance.uiSoundOnClick();
		Destroy(concreteObject);
	}

}
