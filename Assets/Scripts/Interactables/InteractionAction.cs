using UnityEngine;

public class InteractionAction : MonoBehaviour
{
    [SerializeField] protected PlayerController playerController;
    [SerializeField] CharacterType characterType;

    public CharacterType CharacterType { get => characterType; }

    public virtual void Interact(CharacterType character)
    {
        if (character != characterType)
        {
            Debug.Log("No es el personaje correcto");
            return;
        }

        Debug.Log("Interactuó con " + gameObject.name);
    }
}
