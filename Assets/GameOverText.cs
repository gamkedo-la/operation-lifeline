using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    public GameObject gameOverTextObject;
    private Animator gameOverTextAnimator;
    public GameObject tryAgainButton;
    private Animator tryAgainAnimator;
    public GameObject player;
    
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

    public void ActivateAnimator()
    {
        gameOverTextAnimator.enabled = true;
        tryAgainAnimator.enabled = true;
        Debug.Log("inside ActivateChild");
    }
}
