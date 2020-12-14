using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateClimb : State
{
    [SerializeField] private float timeClimb;

    private float distance;
    private float currentTime;

    public float Distance { set => distance = value; }

    private void Awake()
    {
        currentTime = 0f;
    }

    public override void Run()
    {
        while (currentTime < timeClimb)
        {
            currentTime += Time.fixedDeltaTime;
            float speed = distance / timeClimb;
            float tmpDist = Time.fixedDeltaTime * speed;
            cc.Move(Vector3.up * tmpDist);

        }
        currentTime = 0f;
        Terminate();
        return;
    }
}
