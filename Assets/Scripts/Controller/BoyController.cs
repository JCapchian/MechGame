using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class BoyController : BaseController
{
    #region Handlers
    [SerializeField] BoyMovementHandler movementHandler;
    public BoyMovementHandler MovementHandler { get => movementHandler; }
    [SerializeField] BoyStatsHandler boyStatsHandler;
    public BoyStatsHandler BoyStatsHandler { get => boyStatsHandler; }
    [SerializeField] InteractionHandler interactionHandler;
    public InteractionHandler InteractionHandler { get => interactionHandler; }
    #endregion

    [SerializeField] GameObject characterModel;
    public GameObject CharacterModel1 { get => characterModel; set => characterModel = value; }



    public override void Initialize(PlayerController _playerController)
    {
        base.Initialize(_playerController);

        movementHandler.Initialize(playerController, this);
        boyStatsHandler.Initialize(playerController);
        interactionHandler.Initialize(playerController);

        CharacterModel1.SetActive(true);
    }

    public override void Disable()
    {
        base.Disable();
        CharacterModel1.SetActive(false);
    }

    public override void EnableControls()
    {
        base.EnableControls();
        playerController.InputManager.DisableMechControls();
        playerController.InputManager.EnableBoyControls();
    }

    public override void ControllerUpdate()
    {
        interactionHandler.CheckObjectsAround();
    }

    public override void ControllerFixedUpdate()
    {
        movementHandler.HandleMovement();
    }

    public override void ControllerLateUpdate()
    {

    }

}
