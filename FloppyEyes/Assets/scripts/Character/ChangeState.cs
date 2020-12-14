using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : Event
{
    [SerializeField] private State toState;

    private Yuna character;

    private void Start()
    {
        character = GetComponentInParent<Yuna>();
    }

    public override void Execute()
    {
        character.currentState = toState;
    }
}
