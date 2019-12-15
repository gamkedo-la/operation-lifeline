using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    public Transform gameOverText;
    private Animator gameOverTextAnimator;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverText = this.gameObject.transform.GetChild(0);

        GameObject.Find("Player");

        gameOverTextAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position;
    }

    public void ActivateAnimator()
    {
        gameOverTextAnimator.enabled = true;
        Debug.Log("inside ActivateChild");
    }
}
