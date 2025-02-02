using UnityEngine;

public class AbilityCharge : BaseAbility
{
    public override void TryExecute()
    {
        base.TryExecute();
        mechAbilityHandler.OverloadCharge();
    }
}
