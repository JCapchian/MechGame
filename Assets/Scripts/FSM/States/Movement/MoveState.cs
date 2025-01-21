using UnityEngine;

public class MoveState : BaseState<MovementStates>
{
    MovementStates type;
    BoyMovementHandler movementHandler;
    public override MovementStates Type { get => type; }

    public MoveState(MovementStates _type, BoyMovementHandler _movementHandler)
    {
        type = _type;
        movementHandler = _movementHandler;
    }

    public override void OnEnter(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }

    public override void OnExit(BaseStateMachine<MovementStates> baseStateMachine)
    {
        //movementHandler.ResetVelocity();
    }

    public override void OnFixedUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {
        if (movementHandler.CurrentMovementAxi.magnitude == 0)
        {
            baseStateMachine.SwitchState(MovementStates.Idle);
            return;
        }
        movementHandler.Move(movementHandler.WalkModifier, movementHandler.WalkSpeedLimit);
    }

    public override void OnLateUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }

    public override void OnUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }
}
