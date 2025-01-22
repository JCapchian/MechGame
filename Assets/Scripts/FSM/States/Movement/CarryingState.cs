using UnityEngine;

public class CarryingState : BaseState<MovementStates>
{
    MovementStates type;
    BoyMovementHandler movementHandler;
    public override MovementStates Type { get => type; }

    public CarryingState(MovementStates _type, BoyMovementHandler _movementHandler)
    {
        type = _type;
        movementHandler = _movementHandler;
    }

    public override void OnEnter(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }

    public override void OnExit(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }

    public override void OnFixedUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {
        if (movementHandler.CurrentMovementAxi.magnitude == 0)
        {
            movementHandler.ResetVelocity();
            return;
        }
        movementHandler.Move(movementHandler.CarryingModifier, movementHandler.CarryingLimit);
    }

    public override void OnLateUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }

    public override void OnUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }
}