using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOutOfLimit : MonoBehaviour
{
    private float limit;

    private void OnEnable()
    {
        limit = GetComponentInParent<PlatformController>().newPlatformAppearLimit;
    }

    private void Update()
    {
        transform.position -= Vector3.forward * WorldController.CurrentSpeed * Time.deltaTime;
        if (transform.position.z <= limit)
        {
            Destroy(gameObject);
        }
    }
}
