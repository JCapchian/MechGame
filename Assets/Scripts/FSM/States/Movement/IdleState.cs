using UnityEngine;

public class IdleState : BaseState<MovementStates>
{
    MovementStates type;
    BoyMovementHandler movementHandler;
    public override MovementStates Type { get => type; }

    public IdleState(MovementStates _type, BoyMovementHandler _movementHandler)
    {
        type = _type;
        movementHandler = _movementHandler;
    }

    public override void OnEnter(BaseStateMachine<MovementStates> baseStateMachine)
    {
        // if (movementHandler.InAir)
        //     return;

        //movementHandler.ResetVelocity();
    }

    public override void OnExit(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }

    public override void OnFixedUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {
        // if (movementHandler.InAir)
        //     return;

        if (movementHandler.CurrentMouseAxi.magnitude != 0)
            movementHandler.SwitchState(MovementStates.Move);
    }

    public override void OnLateUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }

    public override void OnUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }
}
