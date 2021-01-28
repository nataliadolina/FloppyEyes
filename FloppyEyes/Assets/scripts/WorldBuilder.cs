using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] private GameObject[] freePlatforms;
    [SerializeField] private GameObject[] obstaclePlatforms;

    public Transform platformContainer;
    public static Transform lastPlatform;
    public bool isObstacle;

    Dictionary<bool, GameObject[]> platforms;

    void Start()
    {
        platforms = new Dictionary<bool, GameObject[]>
        {
            {true, obstaclePlatforms},
            {false, freePlatforms},
        };
        platformContainer = FindObjectOfType<WorldController>().transform;
        Init();
    }

    public void Init()
    {
        for (int i = 0; i < 6; i++)
            CreatePlatform();
    }

    public void CreatePlatform(int num = -1)
    {
        int index = -1;
        Vector3 pos = (lastPlatform == null) ?
            platformContainer.position :
            lastPlatform.GetComponent<PlatformController>().endPoint.position;
        if (num == -1)
            index = Random.Range(0, freePlatforms.Length);
        else
            index = num;
        GameObject res = Instantiate(platforms[isObstacle][index], pos, Quaternion.identity, platformContainer);
        lastPlatform = res.transform;
    }
}
