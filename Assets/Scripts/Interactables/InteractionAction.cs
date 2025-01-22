using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionAction : MonoBehaviour
{
    [SerializeField] protected InteractionHandler interactionHandler;
    [SerializeField] protected PlayerController playerController;
    [SerializeField] CharacterType characterType;

    protected virtual void Start() { }

    public CharacterType CharacterType { get => characterType; }

    public void SetHandler(InteractionHandler _interactionHandler)
    {
        interactionHandler = _interactionHandler;
    }

    public virtual void Interact(InteractionHandler _interactionHandler, CharacterType character)
    {
        if (character != characterType)
        {
            Debug.Log("No es el personaje correcto");
            return;
        }
        //interactionHandler = _interactionHandler;
        Debug.Log("Interactuó con " + gameObject.name);
    }
}
