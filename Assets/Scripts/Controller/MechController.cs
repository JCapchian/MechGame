using Unity.VisualScripting;
using UnityEngine;

public class MechController : BaseController
{
    #region Handlers
    [SerializeField] MechMovementHandler mechMovementHandler;
    public MechMovementHandler MechMovementHandler { get => mechMovementHandler; }
    [SerializeField] InteractionHandler interactionHandler;
    public InteractionHandler InteractionHandler { get => interactionHandler; set => interactionHandler = value; }
    #endregion

    bool isActivate;
    public bool IsActivate { get => isActivate; }

    public override void Initialize(PlayerController _playerController)
    {
        base.Initialize(_playerController);

        mechMovementHandler.Initialize(playerController);
        interactionHandler.Initialize(playerController);
    }

    #region Turn On\Off

    public void Activate()
    {
        isActivate = true;
    }
    public void Deactivate()
    {
        isActivate = true;
    }

    #endregion

    public override void ControllerUpdate()
    {
        interactionHandler.CheckObjectsAround();
    }

    public override void ControllerFixedUpdate()
    {
        mechMovementHandler.HandleMovement();
    }

    public override void ControllerLateUpdate()
    {
        base.ControllerLateUpdate();
    }
}
