using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    public GameObject[] freePlatforms;
    public GameObject[] obstaclePlatforms;
    public Transform platformContainer;
    private Transform lastPlatform;
    public GameObject currentPlatform;
    public static WorldBuilder instance;
    public bool isObstacle;
    // Start is called before the first frame update
    private void Awake()
    {
        currentPlatform = freePlatforms[0];
        if (WorldBuilder.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        WorldBuilder.instance = this;
        //DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init()
    {
        CreateFirstPlatform();
        CreateFreePlatform();
        CreateObstaclePlatform();
        CreateFreePlatform();
        CreateObstaclePlatform();
        CreateFreePlatform();
    }
    public void CreatePlatform()
    {
        if (isObstacle)
        {
            CreateFreePlatform();
        }
        else
        {
            CreateObstaclePlatform();
        }
    }
    private void CreateFreePlatform(int num = -1)
    {
        int index = -1;
        Transform endPoint = lastPlatform.GetComponent<PlatformController>().endPoint;
        Vector3 pos = (lastPlatform == null) ?
            platformContainer.position :
            endPoint.position;
        if (num == -1)
            index = Random.Range(0, freePlatforms.Length);
        else
            index = num;
        GameObject res = Instantiate(freePlatforms[index], pos, Quaternion.identity, platformContainer);
        lastPlatform = res.transform;
        currentPlatform = res;
        isObstacle = false;

    }
    private void CreateObstaclePlatform(int num = -1)
    {
        int index = -1;
        Vector3 pos = (lastPlatform == null) ?
            platformContainer.position :
            lastPlatform.GetComponent<PlatformController>().endPoint.position;
        if (num == -1)
            index = Random.Range(0, obstaclePlatforms.Length);
        else
            index = num;
        GameObject res = Instantiate(obstaclePlatforms[index], pos, Quaternion.identity, platformContainer);
        lastPlatform = res.transform;
        currentPlatform = res;
        isObstacle = true;
    }
    private void CreateFirstPlatform()
    {
        Vector3 pos = (lastPlatform == null) ?
            platformContainer.position :
            lastPlatform.GetComponent<PlatformController>().endPoint.position;
        GameObject res = Instantiate(freePlatforms[0], pos, Quaternion.identity, platformContainer);
        lastPlatform = res.transform;
        currentPlatform = res;
        isObstacle = false;
    }
}
