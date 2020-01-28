using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Collectibles

{
    private PlayerController playerController;
    public float thrustMultiplier = 1.2f;
    public float cooldown = 5f;
    float originalThrust;

    protected override void OnTriggerEnter2D(Collider2D collider)
    {

        base.OnTriggerEnter2D(collider);
        GameObject p1 = GameObject.FindGameObjectWithTag("Player");
        if (p1) {
            playerController = p1.GetComponent<PlayerController>();
            originalThrust = playerController.thrust;
            playerController.thrust *= thrustMultiplier;        
            StartCoroutine(Cooldown());
        } else {
            Debug.Log("Speedup Error: player not found");
        }
        
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        playerController.thrust = originalThrust;
        Destroy(gameObject);
    }
}
