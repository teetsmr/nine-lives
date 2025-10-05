using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPickup : MonoBehaviour
{

    public PowerupModifier powerupModifier;

    void OnTriggerEnter2D(Collider2D col)
    {
        var player = col.GetComponent<Player>();
        if (player != null)
        {
            ActivatePowerup(player);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivatePowerup(Player player)
    {
        player.ApplyPowerupModifier(powerupModifier);

        Destroy(gameObject);
    }

}
