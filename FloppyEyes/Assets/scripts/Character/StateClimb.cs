using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateClimb : State
{
    [SerializeField] private float timeClimb;

    private float currentTime;

    private void Awake()
    {
        currentTime = 0f;
    }

    public override void Run()
    {
        if (currentTime < timeClimb)
        {
            currentTime += Time.fixedDeltaTime;
            float speed = distance / timeClimb;
            float tmpDist = Time.fixedDeltaTime * speed;
            cc.Move(Vector3.up * tmpDist);

        }
        else
        {
            currentTime = 0f;
            Terminate();
            return;
        }
    }
}
