using UnityEngine;

public class AbilityFlashlight : BaseAbility
{
    public override void Execute()
    {
        base.Execute();
        mechAbilityHandler.OverloadFlashlight();
    }
}
