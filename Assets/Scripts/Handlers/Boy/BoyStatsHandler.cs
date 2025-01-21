using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;

public class BoyStatsHandler : BaseStateMachine<BoyStates>
{
    BoyController boyController;
    PlayerController playerController;

    [Header("Stats")]
    [SerializeField] int healthPoints;
    public bool isDashing;

    public void Initialize(BoyController _boyController)
    {
        boyController = _boyController;

        LoadStates();
    }

    protected override void LoadStates()
    {
        dictionaryStates = new Dictionary<BoyStates, BaseState<BoyStates>>();

        dictionaryStates.Add(BoyStates.Alive, new AliveState(BoyStates.Alive, this));
        dictionaryStates.Add(BoyStates.Death, new DeathState(BoyStates.Death, this));

        currentState = dictionaryStates[BoyStates.Alive];
    }

    public void TakeDamage()
    {
        if (isDashing)
            return;

        healthPoints--;

        if (healthPoints <= 0)
            Death();
    }

    public void Death()
    {

    }
}
