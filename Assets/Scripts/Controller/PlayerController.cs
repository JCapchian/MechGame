using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] BaseController characterController;
    public BaseController CharacterController { get => characterController; set => characterController = value; }

    private void Awake()
    {
        if (instance != this)
            Destroy(instance);
        else
            instance = this;

        cameraHandler.Initialize(this);

        guiHandler.Initialize(this);

        CharacterController.Initialize(this);
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
}