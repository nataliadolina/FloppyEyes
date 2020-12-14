using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public float initial_speed = 2.5f;
    public float speed_z;
    public float speed;
    public WorldBuilder worldBuilder;

    public delegate void TryDeleteGem();
    public event TryDeleteGem DeleteGem;

    public delegate void TryToDelAndAddPlatform();
    public event TryToDelAndAddPlatform OnPlatformMovement;

    public static WorldController instance;
    public float minZ = -10;
    private float time;
    public GameObject platform;
    // Start is called before the first frame update
    private void Awake() 
    {
        if (WorldController.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        WorldController.instance = this;
        //DontDestroyOnLoad(gameObject);
    }
    //private void OnDestroy()
    //{
    //    WorldController.instance = null;
    //}
    void Start()
    {
        if (PlayerPrefs.HasKey("Speed"))
            speed_z = PlayerPrefs.GetFloat("Speed");
        else
            speed_z = initial_speed;
        speed = speed_z;
        StartCoroutine(OnPlatformMovementCorutine());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 5)
        {
            speed_z += 0.2f;
            time = 0;
        }
        transform.position -= Vector3.forward * speed_z * Time.deltaTime; 
    }
    IEnumerator OnPlatformMovementCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
                if (OnPlatformMovement != null)
                {
                    OnPlatformMovement(); 
                }
                if (DeleteGem != null)
                {
                    DeleteGem();
                }
        }
    }
}
 