using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{

	[SerializeField] private MeshRenderer leftPlayerThruster;
	[SerializeField] private MeshRenderer rightPlayerThruster;
	[SerializeField] private PlayerSounds playerSounds;

	public void SetThrusters(bool leftPlayerThrusting, bool rightPlayerThrusting)
	{
		if (leftPlayerThruster) { leftPlayerThruster.enabled = leftPlayerThrusting; }
		if (rightPlayerThruster) { rightPlayerThruster.enabled = rightPlayerThrusting; }
		float engineBurn = 0.06f;
		if (leftPlayerThrusting) { engineBurn = engineBurn + 0.47f; }
		if (rightPlayerThrusting) { engineBurn = engineBurn + 0.47f; }
		if (playerSounds)
		{
			playerSounds.SetVolume(engineBurn / 100);
		}
	}
}
