using UnityEngine;

public class AliveState : BaseState<BoyStates>
{
    BoyStatsHandler boyStatsHandler;
    BoyStates type;

    public AliveState(BoyStates _type, BoyStatsHandler _boyStatesHandler)
    {
        type = _type;
        boyStatsHandler = _boyStatesHandler;
    }

    public override BoyStates Type { get => type; }

    public override void OnEnter(BaseStateMachine<BoyStates> baseStateMachine)
    {
        
    }

    public override void OnExit(BaseStateMachine<BoyStates> baseStateMachine)
    {
        
    }

    public override void OnFixedUpdate(BaseStateMachine<BoyStates> baseStateMachine)
    {
        
    }

    public override void OnLateUpdate(BaseStateMachine<BoyStates> baseStateMachine)
    {
        
    }

    public override void OnUpdate(BaseStateMachine<BoyStates> baseStateMachine)
    {
        
    }
}
