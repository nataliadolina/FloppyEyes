using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMove : State
{
    [SerializeField] private float timeToSwitchRoad = 0.0f;

    private int currentRoad;
    private int currentDir;
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

    private IEnumerator ChangeRoad()
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
                StartCoroutine(ChangeRoad());
            }
            else if (Input.GetKeyDown(KeyCode.A) && currentRoad > -1)
            {
                currentDir = -1;
                currentTime = 0f;

                distance = ComputeDistance();
                currentRoad -= 1;
                StartCoroutine(ChangeRoad());
            }
        }
    }

    public override void Hit(Collision coll)
    {
        string tag = coll.collider.tag;
        if (tag != "Untagged" & tag != "-")
        {
            Debug.Log("----hitted while moving");
            Lose();
        }     
    }

    public override void Fall()
    {
        Debug.Log("----started falling while moving----");
        character.currentState = character.fall;
    }
}
