using UnityEngine;

public class MechMoveState : BaseState<MechMovementStates>
{
    MechMovementStates type;
    MechMovementHandler mechMovementHandler;

    public MechMoveState(MechMovementStates _type, MechMovementHandler _mechMovementHandler)
    {
        type = _type;
        mechMovementHandler = _mechMovementHandler;
    }

    public override MechMovementStates Type { get => type; }

    public override void OnEnter(BaseStateMachine<MechMovementStates> baseStateMachine)
    {

    }

    public override void OnExit(BaseStateMachine<MechMovementStates> baseStateMachine)
    {
        mechMovementHandler.ResetVelocity();
    }

    public override void OnFixedUpdate(BaseStateMachine<MechMovementStates> baseStateMachine)
    {
        if (mechMovementHandler.CurrentMovementAxi.magnitude == 0)
        {
            baseStateMachine.SwitchState(MechMovementStates.Idle);
            return;
        }
        mechMovementHandler.Move(mechMovementHandler.WalkModifier, mechMovementHandler.WalkSpeedLimit);
    }

    public override void OnLateUpdate(BaseStateMachine<MechMovementStates> baseStateMachine)
    {

    }

    public override void OnUpdate(BaseStateMachine<MechMovementStates> baseStateMachine)
    {

    }
}
