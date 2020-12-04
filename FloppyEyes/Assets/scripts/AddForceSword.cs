using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceSword : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.AddForce(Vector3.right * force);
    }
}
 