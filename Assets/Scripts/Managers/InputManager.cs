using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    InputSystem_Actions inputActions;

    #region Axis Events
    public delegate void OnMovement(Vector2 axis);
    public OnMovement onMovement;
    public delegate void OnMouseMovement(Vector2 axis);
    public OnMouseMovement onMouseMovement;
    #endregion

    #region Actions Events
    public delegate void OnJump();
    public OnJump onJump;
    public delegate void OnSprint(float holdAction);
    public OnSprint onSprint;
    public delegate void OnDash();
    public OnDash onDash;
    public delegate void OnInteraction();
    public OnInteraction onInteraction;
    #endregion

    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new InputSystem_Actions();

            inputActions.Player.Move.performed += i => onMovement?.Invoke(i.ReadValue<Vector2>());
            inputActions.Player.Look.performed += i => onMouseMovement?.Invoke(i.ReadValue<Vector2>());

            inputActions.Player.Jump.performed += i => onJump?.Invoke();
            inputActions.Player.Sprint.performed += i => onSprint?.Invoke(i.ReadValue<float>());
            inputActions.Player.Dash.performed += i => onDash?.Invoke();
            inputActions.Player.Interaction.performed += i => onInteraction?.Invoke();
        }

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }


}
