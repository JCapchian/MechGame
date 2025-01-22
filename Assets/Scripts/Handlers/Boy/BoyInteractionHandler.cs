using System.Linq;
using UnityEngine;

public class BoyInteractionHandler : InteractionHandler
{
    BoyMovementHandler boyMovementHandler;
    [Header("Carrying Object")]
    UpgradeModulePickUp itemToDrop;
    GameObject currentCarryingItem;
    [SerializeField] Transform carryingItemContainer;

    public override void Initialize(PlayerController _playerController)
    {
        base.Initialize(_playerController);
        boyMovementHandler = playerController.BoyController.BoyMovementHandler;
    }

    public override void CheckObjectsAround()
    {
        base.CheckObjectsAround();
        var interactable = Physics.OverlapSphere(transform.position, interactionRadius, interactionLayer);
        // Pregunto si tiene algún objeto
        if (!interactable.Any())
        {
            if (interactionAction != null)
                interactionAction = null;
            return;
        }

        if (currentCarryingItem)
        {
            if (!IsCloseToMech())
                return;

            interactionAction = itemToDrop.upgradeToInstall;
            playerController.InputManager.onInteraction -= DropItem;
            playerController.InputManager.onInteraction += Interact;
            return;
        }

        var objectToInteract = interactable[0].GetComponent<InteractionAction>();

        if (interactionAction != objectToInteract)
            if (objectToInteract.CharacterType == characterType)
                interactionAction = objectToInteract;
    }

    public bool IsCloseToMech()
    {
        var objectsAround = Physics.OverlapSphere(transform.position, interactionRadius);
        foreach (var item in objectsAround)
        {
            if (item.tag == "Mech")
                return true;
        }
        return false;
    }

    #region HoldItem Region

    public void HoldItem(GameObject _itemHold, UpgradeModulePickUp _prefabToDrop)
    {
        // Asigno los objetos nuevos
        currentCarryingItem = _itemHold;
        itemToDrop = _prefabToDrop;
        // Cambio los eventos
        playerController.InputManager.onInteraction -= Interact;
        playerController.InputManager.onInteraction += DropItem;
        // Cambio el estado de movimiento
        boyMovementHandler.SwitchState(MovementStates.Carrying);
        //Hago el objeto parte del personaje
        currentCarryingItem.transform.SetParent(carryingItemContainer);
        currentCarryingItem.transform.position = carryingItemContainer.position;
    }

    public void DropItem()
    {
        // Cambio los eventos
        playerController.InputManager.onInteraction -= DropItem;
        playerController.InputManager.onInteraction += Interact;
        // Cambio el movimiento
        boyMovementHandler.SwitchState(MovementStates.Move);
        // Le quito el padre
        currentCarryingItem.transform.SetParent(null);
        // Vació las referencias
        interactionAction = null;
        currentCarryingItem = null;
        // Le digo al objeto que lo voy a tirar
        itemToDrop.DropPickUp();
        itemToDrop = null;
    }

    #endregion
}
