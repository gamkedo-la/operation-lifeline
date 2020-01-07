using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flasher : MonoBehaviour
{
	[SerializeField] private Light lightAura;
	[SerializeField] private ParticleSystem redParticles;
	[SerializeField] private ParticleSystem blueParticles;
	private Color red;
	private Color blue;
	private float redAlpha;
	private float blueAlpha;

	private void Start()
	{
		red = redParticles.main.startColor.color;
		blue = blueParticles.main.startColor.color;
	}
	void Update()
    {
		float redTime = redParticles.time;
		float blueTime = blueParticles.time;
		redAlpha = redParticles.colorOverLifetime.color.Evaluate(redTime).a;
		blueAlpha = blueParticles.colorOverLifetime.color.Evaluate(blueTime).a;
		red = new Color(red.r, red.g, red.b, redAlpha);
		blue = new Color(blue.r, blue.g, blue.b, blueAlpha);
		if (red.a > blue.a) { lightAura.color = red; }
		else { lightAura.color = blue; }
		//Debug.Log(lightAura.color);
		//Debug.Log("Red: " + red);
		//Debug.Log("Blue: " + blue);
    }
}
