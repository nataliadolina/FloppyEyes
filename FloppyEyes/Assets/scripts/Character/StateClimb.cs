using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateClimb : State
{
    private float timeClimb;
    private float currentTime;

    private void Start()
    {
        currentTime = 0f;
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clips)
        {
            name = clip.name;
            if (name == "Climbing")
            {
                timeClimb = clip.length;
                Debug.Log(timeClimb);
            }
        }
    }

    public override void Run()
    {
        if (currentTime < timeClimb)
        {
            currentTime += Time.deltaTime;
            float speed = distance / timeClimb;
            float tmpDist = Time.deltaTime * speed;
            cc.Move(Vector3.up * tmpDist);
            
        }
        else
        {
            currentTime = 0f;
            WorldController.ContinueMoving();
            Terminate();
            return;
        }
    }
}
