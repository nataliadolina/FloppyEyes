using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform endPoint;
    public GameObject ground;
    private float dist;

    private Transform myTransform;
    
    MeshFilter meshFilter;
    // Start is called before the first frame update
    void Awake()
    {
        meshFilter = ground.GetComponent<MeshFilter>();
        dist = meshFilter.sharedMesh.bounds.size.z * ground.transform.localScale.z;
        WorldController.instance.OnPlatformMovement += TryDelAndAddPlatform;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void TryDelAndAddPlatform()
    {
        if (endPoint.transform.position.z <= WorldController.instance.minZ)
        {
            WorldController.instance.worldBuilder.CreatePlatform();
            Destroy(gameObject);
        }
            
    }
    private void OnDestroy()
    {
        if (WorldController.instance)
        {
            WorldController.instance.OnPlatformMovement -= TryDelAndAddPlatform;
        }

    }
}
