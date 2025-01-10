using UnityEngine;

public class RunState : BaseState<MovementStates>
{
    MovementStates type;
    BoyMovementHandler movementHandler;
    public override MovementStates Type { get => type; }
    float duration;

    public RunState(MovementStates _type, BoyMovementHandler _movementHandler)
    {
        type = _type;
        movementHandler = _movementHandler;
    }

    public override void OnEnter(BaseStateMachine<MovementStates> baseStateMachine)
    {
        duration = movementHandler.RunDuration;
    }

    public override void OnExit(BaseStateMachine<MovementStates> baseStateMachine)
    {
        duration = 0;
    }

    public override void OnFixedUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {
        if (movementHandler.CurrentMovementAxi.magnitude == 0)
        {
            movementHandler.ResetVelocity();
            baseStateMachine.SwitchState(MovementStates.Idle);
            return;
        }

        duration -= Time.deltaTime;

        if (duration > 0)
            movementHandler.Move(movementHandler.RunModifier, movementHandler.RunSpeedLimit);
        else
            movementHandler.SwitchState(MovementStates.Move);
    }

    public override void OnLateUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }

    public override void OnUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }
}
