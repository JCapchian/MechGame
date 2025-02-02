using UnityEngine;

public class InstallModuleAction : InteractionAction
{
    BoyInteractionHandler boyInteractionHandler;
    UpgradeModulePickUp upgradeModulePickUp;
    [SerializeField] ScriptableAbility abilityToInstall;

    public void Initialize(UpgradeModulePickUp _upgradeModulePickUp, BoyInteractionHandler _boyInteractionHandler)
    {
        upgradeModulePickUp = _upgradeModulePickUp;
        boyInteractionHandler = _boyInteractionHandler;
    }

    public override void Interact(InteractionHandler _interactionHandler, CharacterType character)
    {
        base.Interact(_interactionHandler, character);
        playerController.MechController.MechAbilityHandler.InstallAbility(abilityToInstall);

        boyInteractionHandler.DropItem();
        upgradeModulePickUp.gameObject.SetActive(false);
    }
}
