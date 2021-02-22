using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateClimb : State
{
    private float timeClimb;
    private float currentTime;

    private float groundPos = -80f;

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

    public override void Hit(Collision coll)
    {
        if (coll.collider.CompareTag("Untagged") & groundPos == -80f)
        {
            groundPos = coll.transform.position.y;
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
            nextState.distance = characterTransform.position.y - groundPos;
            Terminate();
            return;
        }
    }
}
