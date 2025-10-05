using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupModifier : ScriptableObject
{

    public abstract void Activate(GameObject target);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
