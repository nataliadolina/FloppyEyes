using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceRight : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(rb.gameObject);
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjToPush"))
        {
            rb = other.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.left * force);
        }
    }
}
