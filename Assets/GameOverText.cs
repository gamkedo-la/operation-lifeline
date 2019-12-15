using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    public GameObject gameOverTextObject;
    private Animator gameOverTextAnimator;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverTextAnimator = gameOverTextObject.GetComponent<Animator>();
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
        Debug.Log("inside ActivateChild");
    }
}
