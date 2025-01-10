using UnityEngine;

public class EnterBoyAction : InteractionAction
{
    [SerializeField] MechController mechController;
    [SerializeField] BoyController boyController;
    [SerializeField] CameraHandler cameraHandler;
    public override void Interact(CharacterType character)
    {
        base.Interact(character);

        playerController.CharacterController = boyController;
        boyController.Initialize(playerController);

        boyController.CharacterModel.SetActive(true);

        cameraHandler.ChangeTarget(boyController.transform);
    }
}
