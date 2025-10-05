using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup Effect/Speed Modifier")]
public class SpeedModifier : PowerupModifier
{
    public float newSpeed = 12f;   // absolute speed

    public override void Activate(GameObject target)
    {
        var player = target.transform.root.GetComponent<Player>();
        if (!player) return;

        player.speed = newSpeed;
    }
}
