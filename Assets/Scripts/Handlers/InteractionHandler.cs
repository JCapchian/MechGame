using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    PlayerController playerController;

    [SerializeField] LayerMask interactionLayer;
    [SerializeField] float interactionRange;
    [SerializeField] CharacterType characterType;
    [SerializeField] InteractionAction interactionAction;

    public void Initialize(PlayerController _playerController)
    {
        playerController = _playerController;

        playerController.InputManager.onInteraction += Interact;
    }

    public void CheckObjectsAround()
    {
        var interactable = Physics.OverlapSphere(transform.position, interactionRange, interactionLayer);
        if (interactable.Length == 1)
        {
            interactionAction = null;
            return;
        }
        var objectToInteract = interactable[1].GetComponent<InteractionAction>();

        if (interactionAction != objectToInteract)
            if (objectToInteract.CharacterType == characterType)
                interactionAction = objectToInteract;
    }

    public void Interact()
    {
        if (interactionAction)
            interactionAction.Interact(characterType);
    }

}
