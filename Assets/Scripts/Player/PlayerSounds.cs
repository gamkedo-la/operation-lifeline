using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{

	[SerializeField] private AudioSource thrusterAudioSource = null;
	[SerializeField] private AudioClip thrusterSound = null;
	[Range(0f, 100f)] public float thrusterVolume = 50f;


	private void Awake()
	{
		if (thrusterAudioSource)
		{
			if (thrusterSound) { thrusterAudioSource.clip = thrusterSound; }
			thrusterAudioSource.volume = 0f;
			thrusterAudioSource.Play();
		}
	}

	public void SetVolume(float percent)
	{
		thrusterAudioSource.volume = thrusterVolume * percent;
	}

}
