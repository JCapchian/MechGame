using UnityEngine;

public class MechIdleState : BaseState<MechMovementStates>
{
    MechMovementStates type;
    MechMovementHandler mechMovementHandler;

    public MechIdleState(MechMovementStates _type, MechMovementHandler _mechMovementHandler)
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
        
    }

    public override void OnFixedUpdate(BaseStateMachine<MechMovementStates> baseStateMachine)
    {
        if (mechMovementHandler.CurrentMouseAxi.magnitude != 0)
            mechMovementHandler.SwitchState(MechMovementStates.Move);
    }

    public override void OnLateUpdate(BaseStateMachine<MechMovementStates> baseStateMachine)
    {
        
    }

    public override void OnUpdate(BaseStateMachine<MechMovementStates> baseStateMachine)
    {
        
    }
}
