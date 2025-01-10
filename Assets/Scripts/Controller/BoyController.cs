using NUnit.Framework;
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

    public override void Initialize(PlayerController _playerController)
    {
        base.Initialize(_playerController);

        movementHandler.Initialize(playerController);
        boyStatsHandler.Initialize(playerController);
        interactionHandler.Initialize(playerController);
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
