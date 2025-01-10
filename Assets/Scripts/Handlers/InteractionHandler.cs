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
        Debug.Log(objectToInteract.gameObject.name);

        if (interactionAction != objectToInteract)
            if (objectToInteract.CharacterType == characterType)
                interactionAction = objectToInteract;

        // if (interactable.Any())
        // {
        //     var objectToInteract = interactable[0].GetComponent<InteractionAction>();
        //     if (ownInteractionAction == objectToInteract)
        //         if (interactable[1] != null)
        //             objectToInteract = interactable[1].GetComponent<InteractionAction>();

        //     if (objectToInteract != interactionAction)
        //         if (objectToInteract.CharacterType == characterType)
        //             interactionAction = objectToInteract;
        // }
        // else
        // {
        //     interactionAction = null;
        // }
    }

    public void Interact()
    {
        if (interactionAction)
            interactionAction.Interact(characterType);
    }

}
