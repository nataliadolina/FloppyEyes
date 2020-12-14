﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMove : State
{
    [SerializeField] private float timeToSwitchRoad;

    private int currentRoad;
    private int currentDir;
    private float distance;
    private float currentTime;

    private void Start()
    {
        currentRoad = 0;
        currentTime = 0f;
    }

    private float ComputeDistance()
    {
        float distance = 1 - (character.transform.position.x - currentRoad) * currentDir;
        return distance;
    }

    private IEnumerator Move()
    {
        while (currentTime < timeToSwitchRoad)
        {
            isRunning = true;
            currentTime += Time.deltaTime;
            float speed = distance / timeToSwitchRoad;
            float tmpDist = Time.deltaTime * speed;
            cc.Move(Vector3.right * currentDir * tmpDist);

            yield return new WaitForEndOfFrame();
        }

        isRunning = false;
        currentTime = 0f;
        Terminate();
        yield return null;
    }

    public override void Jump()
    {
        character.currentState = character.jump;
    }

    public override void Run()
    {
        if (!isRunning)
        {
            if (Input.GetKeyDown(KeyCode.D) && currentRoad < 1)
            {
                currentDir = 1;
                currentTime = 0f;

                distance = ComputeDistance();
                currentRoad += 1;
                StartCoroutine(Move());
            }
            else if (Input.GetKeyDown(KeyCode.A) && currentRoad > -1)
            {
                currentDir = -1;
                currentTime = 0f;

                distance = ComputeDistance();
                currentRoad -= 1;
                StartCoroutine(Move());
            }
        }
    }

    public override void Hit(float delta, Collider hitCollider)
    {
        Yuna.Lose();
    }
}