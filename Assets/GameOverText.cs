using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    public GameObject gameOverTextObject;
    private Animator gameOverTextAnimator;
    public GameObject tryAgainButton;
    private Animator tryAgainAnimator;
    public GameObject player;
	public Image FadeToBlackPanel;

    // Start is called before the first frame update
    void Awake()
    {
        gameOverTextAnimator = gameOverTextObject.GetComponent<Animator>();
        tryAgainAnimator = tryAgainButton.GetComponent<Animator>();

        player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {      
        if (player)
        gameObject.transform.position = player.transform.position;
    }

    public void ActivateAnimatorOnPatientDeath()
    {
		StartCoroutine("FadeToBlack");
		gameOverTextAnimator.enabled = true;
        tryAgainAnimator.enabled = true;
    }

	public void ActivateAnimatorOnShipDestruction()
	{
		StartCoroutine("FadeToBlack");
		gameOverTextAnimator.enabled = true;	//TODO: Change to a different text?
		tryAgainAnimator.enabled = true;
	}

	private IEnumerator FadeToBlack()
	{
		Color panelColor = FadeToBlackPanel.color;
		float alpha = 0f;
		for (int i = 0; i < 180; i++)
		{
			panelColor = new Color(panelColor.r, panelColor.g, panelColor.b, alpha);
			alpha = alpha + (1f / 180f);
			yield return new WaitForSeconds(1f/180f);
		}
		
	}

	
}
