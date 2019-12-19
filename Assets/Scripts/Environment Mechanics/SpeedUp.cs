using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Collectibles
{
    private PlayerController playerController;
    public float thrustMultiplier = 1.2f;

    protected override void OnTriggerEnter2D(Collider2D player)
    {
        playerController = player.GetComponent<PlayerController>();
        playerController.thrust *= thrustMultiplier;
        base.OnTriggerEnter2D(player);

    }
}
