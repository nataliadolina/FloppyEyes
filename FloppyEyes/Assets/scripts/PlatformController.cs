using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] public float newPlatformAppearLimit = -10f;
    [SerializeField] public Transform endPoint;

    public GameObject ground;
    private float dist;
    
    private WorldBuilder builder;

    void Awake()
    {
        builder = FindObjectOfType<WorldBuilder>();

        MeshFilter meshFilter = ground.GetComponent<MeshFilter>();
        dist = meshFilter.sharedMesh.bounds.size.z * ground.transform.localScale.z;

        WorldController.OnPlatformMovement += TryDelAndAddPlatform;
        DontDestroyOnLoad(gameObject);
    }

    private void TryDelAndAddPlatform()
    {
        if (endPoint.transform.position.z <= newPlatformAppearLimit)
        {
            builder.CreatePlatform();
            Destroy(gameObject);
        }
            
    }
    private void OnDestroy()
    {
        WorldController.OnPlatformMovement -= TryDelAndAddPlatform;
    }
}
