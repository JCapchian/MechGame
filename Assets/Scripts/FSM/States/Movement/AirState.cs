using UnityEngine;

public class AirState : BaseState<MovementStates>
{
    BoyMovementHandler movementHandler;
    MovementStates type;
    public AirState(MovementStates _type, BoyMovementHandler _movementHandler)
    {
        type = _type;
        movementHandler = _movementHandler;
    }

    public override MovementStates Type => type;

    public override void OnEnter(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }

    public override void OnExit(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }

    public override void OnFixedUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }

    public override void OnLateUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }

    public override void OnUpdate(BaseStateMachine<MovementStates> baseStateMachine)
    {

    }
}
