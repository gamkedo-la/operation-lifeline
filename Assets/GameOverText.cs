using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    [SerializeField] private Animator gameOverPatientDeathAnimator;
	[SerializeField] private Animator gameOverShipDestructionAnimator;
    [SerializeField] private Animator tryAgainAnimator;
    private GameObject player;
	[SerializeField] private Fader fader=null;

    // Start is called before the first frame update
    void Awake()
    {
        //gameOverPatientDeathAnimator = gameOverPatientDeathGO.GetComponent<Animator>();
        //tryAgainAnimator = tryAgainButton.GetComponent<Animator>();

        //player = FindObjectOfType<PlayerController>().gameObject;
		//if (FadeToBlackPanel) { fader = FadeToBlackPanel.gameObject.GetComponent<Fader>(); } 
    }

	// Update is called once per frame
	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
    {   
        if (player)
		{
			gameObject.transform.position = player.transform.position;
		}
    }

    public void ActivateAnimatorOnPatientDeath()
    {
		if (fader) { fader.BeginFadeIn(6f); }
		if (gameOverPatientDeathAnimator) { gameOverPatientDeathAnimator.enabled = true; }
		if (tryAgainAnimator) { tryAgainAnimator.enabled = true; }
    }

	public void ActivateAnimatorOnShipDestruction()
	{
		if (fader) { fader.BeginFadeIn(6f); }
		if (gameOverShipDestructionAnimator) { gameOverShipDestructionAnimator.enabled = true; }
		if (tryAgainAnimator) { tryAgainAnimator.enabled = true; }
	}

	

	
}
