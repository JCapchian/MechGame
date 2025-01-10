using System.Buffers;
using UnityEngine;

public class EnterMechAction : InteractionAction
{
    [SerializeField] MechController mechController;
    [SerializeField] BoyController boyController;
    [SerializeField] CameraHandler cameraHandler;
    public override void Interact(CharacterType character)
    {
        base.Interact(character);

        playerController.CharacterController = mechController;
        mechController.Initialize(playerController);

        boyController.CharacterModel.SetActive(false);

        cameraHandler.ChangeTarget(mechController.transform);
    }
}
