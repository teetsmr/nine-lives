using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup Effect/Health Modifier")]

public class HealthModifier : PowerupModifier
{
    public int healthValue;

    public override void Activate(GameObject target)
    {
        // If the collider came from a child (e.g., GroundCheck), go to the root.
        var root = target.transform.root;
        if (!root.CompareTag("Player")) return;

        if (root.TryGetComponent<Health>(out var health))
        {
            health.Heal(healthValue); // or clamp yourself
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
}
