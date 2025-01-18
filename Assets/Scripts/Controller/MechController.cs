using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;

public class MechController : BaseController
{
    #region Handlers
    [SerializeField] MechMovementHandler mechMovementHandler;
    public MechMovementHandler MechMovementHandler { get => mechMovementHandler; }
    [SerializeField] InteractionHandler interactionHandler;
    public InteractionHandler InteractionHandler { get => interactionHandler; set => interactionHandler = value; }
    #endregion

    [SerializeField] float exitDetectionRadius;
    [SerializeField] float exitDetectionDistance;

    bool isActivate;
    public bool IsActivate { get => isActivate; }

    public override void Initialize(PlayerController _playerController)
    {
        base.Initialize(_playerController);

        mechMovementHandler.Initialize(playerController);
        interactionHandler.Initialize(playerController);

        playerController.InputManager.onExitMech += ExitMech;
    }

    public override void EnableControls()
    {
        base.EnableControls();

        playerController.InputManager.DisableBoyControls();
        playerController.InputManager.EnableMechControls();
    }

    public void ExitMech()
    {
        if (ObstacleInFront())
            return;

        playerController.ChangeToBoy();
        playerController.MoveBoy(new Vector3(transform.position.x, transform.position.y, transform.position.z + exitDetectionDistance));
    }

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

    public bool ObstacleInFront()
    {
        // Ray ray = new Ray(transform.position, transform.forward);
        Collider[] colliders = Physics.OverlapSphere(transform.position + new Vector3(0, 0, exitDetectionDistance), exitDetectionRadius);

        if (colliders.Any())
            return true;
        else
            return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + new Vector3(0, 0, exitDetectionDistance), exitDetectionRadius);
    }
}
