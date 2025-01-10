using UnityEngine;

public class ClimbingState : BaseState<MovementStates>
{
    MovementStates type;
    BoyMovementHandler boyMovementHandler;

    public ClimbingState(MovementStates _type, BoyMovementHandler _boyMovementHandler)
    {
        type = _type;
        boyMovementHandler = _boyMovementHandler;
    }

    public override MovementStates Type { get => type; }



    public override void OnEnter(BaseStateMachine<MovementStates> baseStateMachine)
    {
        Debug.Log("ClimbingState");
        boyMovementHandler.ResetVelocity();
        boyMovementHandler.DeactivateGravity();
        boyMovementHandler.ChangeClimbingInput();
    }

    public override void OnExit(BaseStateMachine<MovementStates> baseStateMachine)
    {
        boyMovementHandler.ActivateGravity();
        boyMovementHandler.ChangeMoveInput();
    }

    public override void OnFixedUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {
        boyMovementHandler.Climb(boyMovementHandler.ClimbSpeedLimit);
    }

    public override void OnLateUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }

    public override void OnUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }
}
