using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
	[SerializeField] private bool faded = false;
	[SerializeField] private float defaultFadeTime = 3f;
	private bool fadeStatusInMemory = false;
	private bool fadingInProgress = false;
	private Image target;

	private void Start()
	{
		target = gameObject.GetComponent<Image>();
	}

	public void BeginFadeIn() { BeginFadeIn(defaultFadeTime); }
	public void BeginFadeIn(float duration)
	{
		if (target)
		{
			object durObj = duration as object;
			StartCoroutine("FadeIn", durObj);
		}
	}

	public void BeginFadeOut() { BeginFadeOut(defaultFadeTime); }
	public void BeginFadeOut(float duration)
	{
		if (target)
		{
			object durObj = duration as object;
			StartCoroutine("FadeOut", durObj);
		}
		
	}

	
	

	private IEnumerator FadeIn(object durObj)
	{
		float duration = (float)durObj;
		Color newColor = target.color;
		float alpha = 0f;
		float targetAlpha = 1f;
		for (float i = 0f; i < duration; i += Time.deltaTime)
		{
			//panelColor = new Color(panelColor.r, panelColor.g, panelColor.b, alpha);
			newColor = new Color(newColor.r, newColor.g, newColor.b, alpha);
			target.color = newColor;
			alpha = alpha + (targetAlpha / duration) * Time.deltaTime;
			alpha = Mathf.Clamp(alpha, 0f, targetAlpha);
			yield return null;
		}
		
	}

	private IEnumerator FadeOut(object durObj)
	{
		float duration = (float)durObj;
		Color targetColor = target.color;
		float alpha = target.color.a;
		for (float i = 0f; i < duration; i += Time.deltaTime)
		{
			targetColor = new Color(targetColor.r, targetColor.g, targetColor.b, alpha);
			alpha = alpha - (1 / duration) * Time.deltaTime;
			alpha = Mathf.Clamp(alpha, 0f, 1f);
			yield return null;
		}
	}

	private void Update()
	{
		if (fadingInProgress) 
		{
			faded = fadeStatusInMemory;
			return;
		}
		if (faded && !fadeStatusInMemory) { BeginFadeIn(); }
		else if (!faded && fadeStatusInMemory) { BeginFadeOut(); }
	}

}
