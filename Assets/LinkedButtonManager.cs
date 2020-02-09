using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class LinkedButtonManager : MonoBehaviour
{
	[SerializeField] private Image leftStartButton = null;
	[SerializeField] private Image rightStartButton = null;
	[SerializeField] private Image loadingButton = null;
	[SerializeField] private string levelToLoad = "";
	private bool leftButtonPressed = false;
	private bool rightButtonPressed = false;
	private Color blueColor = Color.blue;
	private Color greenColor = Color.green;

	private void Start()
	{
		blueColor = new Color(10f/255f, 162f/255f, 245f/255f, 255f/255f);
		greenColor = new Color(0f/255f, 236f/255f, 18f/255f, 255f/255f);
		leftStartButton.color = blueColor;
		rightStartButton.color = blueColor;
	}

	void Update()
    {
		PlayerInput.CheckInput();
		
		if (PlayerInput.LeftThrust && !leftButtonPressed && leftStartButton) 
		{
			PressLeftButton();
			if (rightButtonPressed) { StartLevel(); }
		}
		if (PlayerInput.RightThrust && !rightButtonPressed && rightStartButton)
		{
			PressRightButton();
			if (leftButtonPressed) { StartLevel(); }
		}
    }

	void PressLeftButton()
	{
		//leftStartButton.interactable = true;
		//ExecuteEvents.Execute(leftStartButton.gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
		leftStartButton.color = greenColor;
		leftButtonPressed = true;
		GameManager.Instance.uiSoundOnHover();
	}

	void PressRightButton()
	{
		//rightStartButton.interactable = true;
		//ExecuteEvents.Execute(rightStartButton.gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
		rightStartButton.color = greenColor;
		rightButtonPressed = true;
		GameManager.Instance.uiSoundOnHover();
	}

	void StartLevel()
	{
		
		if (loadingButton && loadingButton.gameObject.activeSelf==true) 
		{
			loadingButton.enabled = true;
			TextMeshProUGUI text = loadingButton.GetComponentInChildren<TextMeshProUGUI>();
			if (text) { text.text = "Loading..."; }
		}
		GameManager.Instance.LoadScene(levelToLoad);
        GameManager.Instance.uiSoundOnClick();
    }
}
