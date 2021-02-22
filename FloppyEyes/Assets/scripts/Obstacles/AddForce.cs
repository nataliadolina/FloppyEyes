using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    left,
    right
}

public abstract class AddForce : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private Direction direction;

    private Rigidbody rb;
    private Dictionary<Direction, Vector3> forceDirection;

    protected void Start()
    {
        forceDirection = new Dictionary<Direction, Vector3>()
        {
            { Direction.left, Vector3.left},
            { Direction.right, Vector3.right}
        };

        rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.AddForce(-forceDirection[direction] * force);
    }
    
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InvisibleWall"))
        {
            rb.AddForce(forceDirection[direction] * force * 0.02f, ForceMode.Impulse);
        }
    }
}
