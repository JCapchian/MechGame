using System.Buffers;
using UnityEngine;

public class EnterMechAction : InteractionAction
{
    public override void Interact(CharacterType character)
    {
        base.Interact(character);

        playerController.ChangeToMech();
    }
}
