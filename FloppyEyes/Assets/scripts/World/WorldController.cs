using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldController : MonoBehaviour
{
    [SerializeField] static float initial_speed = 2.5f;
    static float cur_speed = 0f;
    static float speed = 0f;

    public static float CurrentSpeed { get => cur_speed; set => cur_speed = value; }
    public static float LastSpeed { get => speed; set => speed = value; }

    public static event Action OnPlatformMovement;

    private float timeSinceLastAccelerate;

    void Start()
    {
        if (!PlayerPrefs.HasKey("hasLost") && PlayerPrefs.HasKey("Speed"))
            cur_speed = PlayerPrefs.GetFloat("Speed");
        else
            cur_speed = initial_speed;
        speed = cur_speed;
        StartCoroutine(OnPlatformMovementCoroutine());
    }

    void Update()
    {
        timeSinceLastAccelerate += Time.deltaTime;
        if (timeSinceLastAccelerate >= 5)
        {
            cur_speed += 0.2f;
            timeSinceLastAccelerate = 0;
        }
        transform.position -= Vector3.forward * cur_speed * Time.deltaTime; 
    }

    private IEnumerator OnPlatformMovementCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
                if (OnPlatformMovement != null)
                {
                    OnPlatformMovement(); 
                }
        }
    }

    public static void SaveCurrentSpeed()
    {
        speed = cur_speed;
    }

    public static void StopMoving()
    {
        cur_speed = 0f;
    }

    public static void ContinueMoving()
    {
        cur_speed = speed;
    }
}
 