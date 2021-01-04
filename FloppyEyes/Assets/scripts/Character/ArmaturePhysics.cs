using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaturePhysics : MonoBehaviour
{
    private Rigidbody[] armatureRb;
    private Collider[] armatureColliders;

    void Awake()
    {
        Yuna.Lose += TurnOn;
        Yuna.FreezeRagdoll += TurnOff;

        armatureRb = GetComponentsInChildren<Rigidbody>();
        armatureColliders = GetComponentsInChildren<Collider>();
    }

    private void TurnOff()
    {
        foreach (var rb in armatureRb)
        {
            rb.isKinematic = true;
        }

        foreach (var coll in armatureColliders)
        {
            coll.enabled = false;
        }
    }
    
    private void TurnOn()
    {
        foreach (var rb in armatureRb)
        {
            rb.isKinematic = false;
        }

        foreach (var coll in armatureColliders)
        {
            coll.enabled = true;
        }
    }
}
