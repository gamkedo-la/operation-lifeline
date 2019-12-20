using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Collectibles
{
    private PlayerController playerController;
    public float thrustMultiplier = 1.2f;
    public float cooldown = 5f;
    float originalThrust;

    protected override void OnTriggerEnter2D(Collider2D player)
    {
        playerController = player.GetComponent<PlayerController>();
        originalThrust = playerController.thrust;
        playerController.thrust *= thrustMultiplier;
        base.OnTriggerEnter2D(player);
        StartCoroutine(Cooldown());
        
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        playerController.thrust = originalThrust;
        Destroy(gameObject);
    }
}
