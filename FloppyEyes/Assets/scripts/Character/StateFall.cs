using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFall : State
{
    private float currentSpeed = 0.0f;

    public override void Run()
    {
        if (distance > 0f)
        {
            currentSpeed -= StateJump.gravity * Time.deltaTime;
            float tmpDist = Time.deltaTime * currentSpeed;
            distance += tmpDist;
            Debug.Log(distance);
            cc.Move(Vector3.up * tmpDist);
        }
        else
        {
            Terminate();
        }
            
    }

    public override void Hit(Collision hit)
    {
        Debug.Log("----Hites while falling------");
        Terminate();
    }
}
