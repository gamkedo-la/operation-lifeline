using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBarUIController : MonoBehaviour
{
	Slider shieldBar = null;
	Image[] shieldBarImages = new Image[2];
	

	// Start is called before the first frame update
	void Start()
    {
		shieldBar = GetComponent<Slider>();
		if (shieldBar) { shieldBarImages = shieldBar.GetComponentsInChildren<Image>(); }
		HideShieldBar();
	}

	private void HideShieldBar()
	{
		if (shieldBarImages.Length == 0) { return; }
		foreach (Image shieldBarImage in shieldBarImages)
		{
			if (shieldBarImage)
			{
				shieldBarImage.enabled = false;
			}

		}
	}
}
