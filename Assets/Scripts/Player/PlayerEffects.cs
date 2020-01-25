using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{

    [SerializeField] private MeshRenderer leftPlayerThruster = null;
    [SerializeField] private MeshRenderer rightPlayerThruster = null;
    [SerializeField] private GameObject leftThrusterPFX = null;
    [SerializeField] private GameObject rightThrusterPFX = null;
    [SerializeField] private PlayerSounds playerSounds = null;

    private ParticleSystem.EmissionModule left_pfx_emitter;
    private ParticleSystem.EmissionModule right_pfx_emitter;

    public void Start()
    {
		var left_pfx = leftThrusterPFX.GetComponent(typeof(ParticleSystem)) as ParticleSystem;
		var right_pfx = rightThrusterPFX.GetComponent(typeof(ParticleSystem)) as ParticleSystem;
		left_pfx_emitter = left_pfx.emission;
		right_pfx_emitter = right_pfx.emission;
    }

	public void SetThrusters(bool leftPlayerThrusting, bool rightPlayerThrusting)
	{
		if (leftPlayerThruster) { leftPlayerThruster.enabled = leftPlayerThrusting; }
		if (rightPlayerThruster) { rightPlayerThruster.enabled = rightPlayerThrusting; }
		float engineBurn = 0.06f;

		if (leftPlayerThrusting)
        {
            engineBurn = engineBurn + 0.47f;
            left_pfx_emitter.enabled = true;
        }
        else
        {
            left_pfx_emitter.enabled = false;
        }

        if (rightPlayerThrusting)
        {
            engineBurn = engineBurn + 0.47f;
            right_pfx_emitter.enabled = true;
        }
        else
        {
            right_pfx_emitter.enabled = false;
        }

        if (playerSounds)
		{
			playerSounds.SetVolume(engineBurn / 100);
		}
	}
}
