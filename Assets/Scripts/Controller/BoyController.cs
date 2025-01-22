using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class BoyController : BaseController
{
    #region Handlers
    [SerializeField] BoyMovementHandler boyMovementHandler;
    public BoyMovementHandler BoyMovementHandler { get => boyMovementHandler; }
    [SerializeField] BoyStatsHandler boyStatsHandler;
    public BoyStatsHandler BoyStatsHandler { get => boyStatsHandler; }
    [SerializeField] BoyInteractionHandler boyInteractionHandler;
    public BoyInteractionHandler BoyInteractionHandler { get => boyInteractionHandler; }
    [SerializeField] BoyAbilityHandler boyAbilityHandler;
    public BoyAbilityHandler BoyAbilityHandler { get => boyAbilityHandler; }
    #endregion

    [SerializeField] GameObject characterModel;
    public GameObject CharacterModel { get => characterModel; set => characterModel = value; }

    [SerializeField] float enterMechRadius;

    public override void Initialize(PlayerController _playerController)
    {
        base.Initialize(_playerController);

        boyMovementHandler.Initialize(playerController, this);
        boyStatsHandler.Initialize(this);
        boyInteractionHandler.Initialize(playerController);
        boyAbilityHandler.Initialize(this);

        CharacterModel.SetActive(true);

        playerController.InputManager.onEnterMech += EnterMech;
    }

    public override void Disable()
    {
        base.Disable();
        CharacterModel.SetActive(false);
    }

    public override void EnableControls()
    {
        base.EnableControls();
        playerController.InputManager.DisableMechControls();
        playerController.InputManager.EnableBoyControls();
    }

    public void EnterMech()
    {
        var pepe = Physics.OverlapSphere(transform.position, enterMechRadius);
        foreach (var item in pepe)
        {
            if (item.GetComponent<MechController>())
            {
                EnterMech();
                return;
            }
        }
    }

    #region Update Region

    public override void ControllerUpdate()
    {
        boyInteractionHandler.CheckObjectsAround();
    }

    public override void ControllerFixedUpdate()
    {
        boyMovementHandler.HandleMovement();
    }

    public override void ControllerLateUpdate()
    {

    }

    #endregion
}
