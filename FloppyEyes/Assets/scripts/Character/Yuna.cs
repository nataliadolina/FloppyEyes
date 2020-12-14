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
    private Rigidbody[] bodyRigidBodies;

    void Start()
    {
        states = new Dictionary<StatesEnum, State>
        {
            { StatesEnum.Run, run },
            { StatesEnum.Jump, jump },
            { StatesEnum.Climb, climb},
            { StatesEnum.Lose, lose}
        };

        yunaAnim = GetComponent<Animator>();
        bodyRigidBodies = GetComponentsInChildren<Rigidbody>();

        TurnOffRigidBodies();
        Lose += TurnOnRigidBodies;
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

    private void TurnOnRigidBodies()
    {
        foreach (var body in bodyRigidBodies)
        {
            body.isKinematic = false;
        }
    }

    private void TurnOffRigidBodies()
    {
        foreach (var body in bodyRigidBodies)
        {
            body.isKinematic = true;
        }
    }

}
