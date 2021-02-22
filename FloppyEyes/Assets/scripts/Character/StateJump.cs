using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateJump : State
{
    [SerializeField] private float startSpeed;
    [SerializeField] public static float gravity = 40.0f;

    private float startHeight;
    private float currentSpeed;

    private float timeJump;
    private float currentTime;

    private float stepOffset;

    private void Start()
    { 
        startHeight = character.transform.position.y;
        currentSpeed = startSpeed;
        timeJump = 2 * startSpeed / gravity;
        stepOffset = cc.stepOffset;
    }

    public override void Run()
    {
        if (currentTime < timeJump)
        {
            currentTime += Time.deltaTime;
            currentSpeed -= gravity * Time.deltaTime;
            float tmpDist = Time.deltaTime * currentSpeed;
            cc.Move(Vector3.up * tmpDist);

        }
        else
        {
            currentSpeed = startSpeed;
            currentTime = 0f;
            character.transform.position = new Vector3(character.transform.position.x, startHeight, character.transform.position.z);
            Terminate();
        }
    }

    public override void Hit(Collision hit)
    {
        
        Transform otherTransform = hit.transform;
        Collider hitCollider = hit.collider;
        float delta = otherTransform.localScale.y - characterTransform.position.y + characterTransform.localScale.y * 0.75f;
        Debug.Log(delta);
        if (delta > 5 || hitCollider.CompareTag("kill"))
        {
            Lose();
            return;
        }
        
        else if (hitCollider.CompareTag("Obstacle"))
        {
            if (delta <= 5 & delta > stepOffset)
            {
                animator.SetTrigger("climb");
                WorldController.SaveCurrentSpeed();
                WorldController.StopMoving();
                hitCollider.tag = "-";
                character.currentState = character.climb;
                character.currentState.distance = delta;
                return;
            }
            else if (delta <= stepOffset)
            {
                hitCollider.tag = "-";
                return;
            }
        }
        
    }
}
