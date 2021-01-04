using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private State nextState;

    [HideInInspector] public float distance;

    protected State[] otherStates;
    protected Yuna character;
    protected bool isRunning;
    protected Animator animator;
    protected CharacterController cc;
    protected Transform characterTransform;

    private void Awake()
    {
        character = GetComponentInParent<Yuna>();
        characterTransform = character.gameObject.transform;
        animator = character.gameObject.GetComponent<Animator>();
        cc = character.gameObject.GetComponent<CharacterController>();
    }

    public abstract void Run();

    protected void Terminate()
    {
        character.currentState = nextState;
    }
    public virtual void Move()
    {

    }

    public virtual void Hit(ControllerColliderHit hit)
    {

    }

    public virtual void Jump()
    {

    }
}
