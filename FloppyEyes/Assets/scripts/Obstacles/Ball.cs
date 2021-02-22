using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject targetingGreen;
    [SerializeField] private GameObject targetingRed;

    private GameObject target;
    
    private void Start()
    {
        target = Instantiate(targetingGreen, new Vector3(transform.position.x, 0.4f, transform.position.z), Quaternion.Euler(90, 0, 0), WorldBuilder.lastPlatform.transform);
    }

    private void Update()
    {
        Destroy(target.gameObject);
        if (transform.position.y <= 3.5f)
        {
            target = Instantiate(targetingRed, new Vector3(transform.position.x, 0.4f, transform.position.z), Quaternion.Euler(90, 0, 0), WorldBuilder.lastPlatform.transform);
        }
        else if (transform.position.y > 3.5f)
        {
            target = Instantiate(targetingGreen, new Vector3(transform.position.x, 0.4f, transform.position.z), Quaternion.Euler(90, 0, 0), WorldBuilder.lastPlatform.transform);
        }
    }
    
}
