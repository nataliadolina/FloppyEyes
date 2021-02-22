using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private GameObject endpoint;
    [SerializeField] private GameObject startpoint;

    private LineRenderer line;
    
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        line.SetPosition(0, startpoint.transform.position);
        line.SetPosition(1, endpoint.transform.position);
    }
}
