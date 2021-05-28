using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] protected State nextState;

    [HideInInspector] public float distance;

    protected State[] otherStates;
    protected Yuna character;
    protected bool isRunning;
    protected Animator animator;
    protected CharacterController cc;
    protected Transform characterTransform;
    protected GameManage gameManager;

    private void OnEnable()
    {
        character = GetComponentInParent<Yuna>();
        characterTransform = character.transform;
        animator = character.GetComponent<Animator>();
        cc = character.GetComponent<CharacterController>();
        gameManager = FindObjectOfType<GameManage>();
    }

    public abstract void Run();

    protected void Terminate()
    {
        character.currentState = nextState;
    }

    protected void Lose()
    {
        animator.enabled = false;
        SaveSettings.Save();
        Yuna.Lose();
        WorldController.StopMoving();
        gameManager.Restart(2.5f);
    }

    public virtual void Move()
    {

    }

    public virtual void Fall()
    {
        
    }

    public virtual void Hit(Collision coll)
    {

    }

    public virtual void Jump()
    {

    }
}
