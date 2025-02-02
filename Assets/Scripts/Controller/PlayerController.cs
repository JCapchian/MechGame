using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] InputManager inputManager;
    public InputManager InputManager { get => inputManager; }

    #region Handlers
    [SerializeField] CameraHandler cameraHandler;
    public CameraHandler CameraHandler { get => cameraHandler; }
    [SerializeField] GuiHandler guiHandler;
    public GuiHandler GuiHandler { get => guiHandler; }
    #endregion

    #region Controllers
    [SerializeField] BoyController boyController;
    public BoyController BoyController { get => boyController; }
    [SerializeField] MechController mechController;
    public MechController MechController { get => mechController; }
    [SerializeField] BaseController characterController;
    public BaseController CharacterController { get => characterController; set => characterController = value; }
    #endregion

    private void Awake()
    {
        if (instance != this)
            Destroy(instance);
        else
            instance = this;

        cameraHandler.Initialize(this);
        guiHandler.Initialize(this);

        boyController.Initialize(this);
        mechController.Initialize(this);

        CharacterController.Initialize(this);
    }
    private void Start()
    {
        characterController.EnableControls();
    }

    private void LateUpdate()
    {
        cameraHandler.Handle();
        characterController.ControllerLateUpdate();
    }

    private void FixedUpdate()
    {
        characterController.ControllerFixedUpdate();
    }

    private void Update()
    {
        characterController.ControllerUpdate();
    }

    public void ChangeToBoy()
    {
        guiHandler.HideMechGui();
        guiHandler.ShowBoyGui();
        
        if (characterController == boyController)
            return;

        cameraHandler.ChangeTarget(boyController.transform);
        characterController.Disable();
        characterController = boyController;


        characterController.Initialize(this);
        characterController.EnableControls();
    }

    public void MoveBoy(Vector3 vector3)
    {
        characterController.transform.position = vector3;
    }
    public void ChangeToMech()
    {
        guiHandler.HideBoyGui();
        guiHandler.ShowMechGui();

        if (characterController == mechController)
            return;

        cameraHandler.ChangeTarget(mechController.transform);
        characterController.Disable();
        characterController = mechController;


        characterController.Initialize(this);
        characterController.EnableControls();
    }
}