using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{

    private GameObject player;
    private PlayerController playerController;
    private PlayerHealth playerHealth;
    public bool infiniteHealth = false;
    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        playerHealth = player.GetComponent<PlayerHealth>();
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = FindObjectOfType<PlayerController>().gameObject;
        }
    }

    public void InfiniteHealth()
    {
        if (infiniteHealth)
        {
            infiniteHealth = false;
            playerHealth.enabled = true;
        }
        else
        {
            infiniteHealth = true;
            playerHealth.enabled = false;
        }
    }

    public void KillPlayer()
    {
        if(playerHealth.enabled == false)
        {
            playerHealth.enabled = true;
        }
        playerHealth.Die();
    }
}
