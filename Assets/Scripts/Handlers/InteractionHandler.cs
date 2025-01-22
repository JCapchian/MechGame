using System.Linq;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    protected PlayerController playerController;

    [Header("Variables")]
    [SerializeField] protected LayerMask interactionLayer;
    [SerializeField] protected float interactionRadius;
    [SerializeField] protected CharacterType characterType;
    protected InteractionAction interactionAction;

    public virtual void Initialize(PlayerController _playerController)
    {
        playerController = _playerController;

        playerController.InputManager.onInteraction += Interact;
    }

    public virtual void CheckObjectsAround()
    {
        var interactable = Physics.OverlapSphere(transform.position, interactionRadius, interactionLayer);
        // Pregunto si tiene algún objeto
        if (!interactable.Any())
        {
            if (interactionAction != null)
                interactionAction = null;
            return;
        }

        var objectToInteract = interactable[0].GetComponent<InteractionAction>();

        if (interactionAction != objectToInteract)
            if (objectToInteract.CharacterType == characterType)
                interactionAction = objectToInteract;
    }

    public void Interact()
    {
        if (interactionAction)
            interactionAction.Interact(this, characterType);
    }
}
