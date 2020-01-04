using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : Collectibles
{
    public GameObject shieldPrefab;
    public Transform shipTransform;

    protected override void OnTriggerEnter2D(Collider2D player)
    {
        base.OnTriggerEnter2D(player);
        shieldPrefab = Instantiate(shieldPrefab) as GameObject;
        shieldPrefab.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        shieldPrefab.transform.position = shipTransform.position;
        Destroy(gameObject);
    }
}
