using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollManage : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        YunaController.instance.turnonrb += TurnOnRb;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TurnOnRb()
    {
        rb.isKinematic = false;
    }
    void TurnOffRb()
    {
        rb.isKinematic = true;
    }
}
