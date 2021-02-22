using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaturePhysics : MonoBehaviour
{
    private Rigidbody[] armatureRb;
    private Collider[] armatureColliders;

    private void OnEnable()
    {
        Yuna.Lose += TurnOn;
         
        armatureRb = GetComponentsInChildren<Rigidbody>();
        armatureColliders = GetComponentsInChildren<Collider>();
    }
    
    private void TurnOn()
    {
        foreach (var rb in armatureRb)
        {
            if (rb != null)
                rb.isKinematic = false;
        }

        foreach (var coll in armatureColliders)
        {
            if (coll != null)
                coll.enabled = true;
        }
    }
}
