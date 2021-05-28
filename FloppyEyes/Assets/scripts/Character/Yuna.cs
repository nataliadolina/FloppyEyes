using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Yuna : MonoBehaviour
{
    [SerializeField] public State run;
    [SerializeField] public State jump;
    [SerializeField] public State climb;
    [SerializeField] public State fall;

    public static Action Lose;
    public static Action Restart;

    private Animator yunaAnim;
    public State currentState;

    void Start()
    {
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

    private void OnCollisionEnter(Collision coll)
    {
        currentState.Hit(coll);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("CollisionExit");
        currentState.Fall();
    }


}
