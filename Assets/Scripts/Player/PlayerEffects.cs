using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{

    [SerializeField] private MeshRenderer leftPlayerThruster;
    [SerializeField] private MeshRenderer rightPlayerThruster;
    [SerializeField] private GameObject leftThrusterPFX;
    [SerializeField] private GameObject rightThrusterPFX;
    [SerializeField] private PlayerSounds playerSounds;

    private ParticleSystem left_pfx;
    private ParticleSystem right_pfx;

    public void Start()
    {
        left_pfx = leftThrusterPFX.GetComponent(typeof(ParticleSystem)) as ParticleSystem;
        right_pfx = rightThrusterPFX.GetComponent(typeof(ParticleSystem)) as ParticleSystem;
    }

	public void SetThrusters(bool leftPlayerThrusting, bool rightPlayerThrusting)
	{
		if (leftPlayerThruster) { leftPlayerThruster.enabled = leftPlayerThrusting; }
		if (rightPlayerThruster) { rightPlayerThruster.enabled = rightPlayerThrusting; }
		float engineBurn = 0.06f;

		if (leftPlayerThrusting)
        {
            engineBurn = engineBurn + 0.47f;
            left_pfx.enableEmission = true;
        }
        else
        {
            left_pfx.enableEmission = false;
        }

        if (rightPlayerThrusting)
        {
            engineBurn = engineBurn + 0.47f;
            right_pfx.enableEmission = true;
        }
        else
        {
            right_pfx.enableEmission = false;
        }

        if (playerSounds)
		{
			playerSounds.SetVolume(engineBurn / 100);
		}
	}
}
