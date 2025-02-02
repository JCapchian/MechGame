using UnityEngine;

public class JumpingState : BaseState<MovementStates>
{
    BoyMovementHandler movementHandler;
    MovementStates type;
    public JumpingState(MovementStates _type, BoyMovementHandler _movementHandler)
    {
        type = _type;
        movementHandler = _movementHandler;
    }

    public override MovementStates Type => type;

    public override void OnEnter(BaseStateMachine<MovementStates> baseStateMachine)
    {
        movementHandler.Jump();
    }

    public override void OnExit(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }

    public override void OnFixedUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {
        if (!movementHandler.IsGrounded)
            movementHandler.SwitchState(MovementStates.Idle);
    }

    public override void OnLateUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }

    public override void OnUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }
}
