using Unity.VisualScripting;
using UnityEngine;

public class UpgradeModulePickUp : InteractionAction
{
    BoyInteractionHandler boyInteractionHandler;
    [SerializeField] Rigidbody rb;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] UpgradeModulePickUp prefabToDrop;
    [SerializeField] GameObject itemHold;
    public InstallModuleAction upgradeToInstall;

    protected override void Start()
    {
        base.Start();
        boyInteractionHandler = playerController.BoyController.BoyInteractionHandler;

        upgradeToInstall.Initialize(this, boyInteractionHandler);
    }

    public override void Interact(InteractionHandler interactionHandler, CharacterType character)
    {
        base.Interact(interactionHandler, character);

        boyInteractionHandler.HoldItem(itemHold, prefabToDrop);
        boxCollider.isTrigger = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        upgradeToInstall.SetHandler(interactionHandler);
    }

    public void DropPickUp()
    {
        boxCollider.isTrigger = false;
        rb.constraints = RigidbodyConstraints.None;
    }
}
