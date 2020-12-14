using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateJump : State
{
    [SerializeField] private float startSpeed;
    [SerializeField] private float gravity;

    private float startHeight;
    private float currentSpeed;

    private float timeJump;
    private float currentTime;

    private void Start()
    {
        startHeight = character.transform.position.y;
        currentSpeed = startSpeed;
        timeJump = 2 * startSpeed / gravity;
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
