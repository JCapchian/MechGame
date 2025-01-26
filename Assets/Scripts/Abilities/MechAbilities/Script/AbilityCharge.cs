using UnityEngine;

public class AbilityCharge : BaseAbility
{
    public override void Execute()
    {
        base.Execute();
        mechAbilityHandler.OverloadCharge();
    }
}
