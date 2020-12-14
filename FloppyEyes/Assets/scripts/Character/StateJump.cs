using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateJump : State
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private float timeJump;
    [SerializeField] private float gravity;

    private float startHeight;
    private float currentTime;
    private float startSpeed;

    private void Start()
    {
        currentTime = 0f;
        startSpeed = jumpHeight / timeJump + gravity * timeJump / 2;
    }

    public override void Run()
    {
        if (currentTime < timeJump)
        {
            currentTime += Time.deltaTime;
            startSpeed -= gravity * Time.deltaTime;
            float tmpDist = Time.deltaTime * startSpeed;
            cc.Move(Vector3.up * tmpDist);

        }
        else
        {
            currentTime = 0f;
            Debug.Log("Jump reset");
            Terminate();
            return;
        }
    }

    public override void Hit(float delta, Collider hitCollider)
    {
        animator.SetTrigger("climb");
        if (delta <= 5 && delta > 0.6)
        {
            character.currentState = character.climb;
        }
        else if (delta <= 0.6) /*делаем препятсвтие безопасным*/
        {
            hitCollider.tag = "-";
        }

        else if (delta > 5) /*если слишком высоко, то игра заканчивается*/
            Yuna.Lose();
    }
}
