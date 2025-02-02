using UnityEngine;

public class AbilityFlashlight : BaseAbility
{
    public override void TryExecute()
    {
        base.TryExecute();
        mechAbilityHandler.OverloadFlashlight();
    }
}
