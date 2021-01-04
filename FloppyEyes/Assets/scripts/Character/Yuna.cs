using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum StatesEnum
{
    Run,
    Jump,
    Climb,
    Lose
}

public class Yuna : MonoBehaviour
{
    [SerializeField] public State run;
    [SerializeField] public State jump;
    [SerializeField] public State climb;
    [SerializeField] public State lose;

    private Animator yunaAnim;
    public State currentState;
    private Dictionary<StatesEnum, State> states;

    public static Action Lose;
    public static Action FreezeRagdoll;

    void Start()
    {
        states = new Dictionary<StatesEnum, State>
        {
            { StatesEnum.Run, run },
            { StatesEnum.Jump, jump },
            { StatesEnum.Climb, climb},
            { StatesEnum.Lose, lose}
        };

        FreezeRagdoll();
        yunaAnim = GetComponent<Animator>();

    }
    
    private void Update()
    {
        currentState.Run();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            yunaAnim.SetTrigger("jump");
            currentState.Jump();
        }

        if (Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.D))
        {
            currentState.Move();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        currentState.Hit(hit);
    }
}
