using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    InputSystem_Actions inputActions;

    #region Axis Events
    public delegate void OnMovement(Vector2 axis);
    public OnMovement onMovement;
    public delegate void OnInteraction();
    public OnInteraction onInteraction;
    #endregion

    #region Actions Events
    #endregion

    #region BoyAction Events
    public delegate void OnEnterMech();
    public OnEnterMech onEnterMech;
    public delegate void OnJump();
    public OnJump onJump;
    public delegate void OnAttack();
    public OnAttack onAttack;
    public delegate void OnSprint(float holdAction);
    public OnSprint onSprint;
    public delegate void OnDash();
    public OnDash onDash;
    #endregion

    #region MechAction Events
    public delegate void OnExitMech();
    public OnExitMech onExitMech;
    public delegate void OnAbilityCharge();
    public OnAbilityCharge onAbilityCharge;
    public delegate void OnAbilityFlashlight();
    public OnAbilityFlashlight onAbilityFlashlight;
    #endregion

    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new InputSystem_Actions();

            inputActions.GeneralControls.Move.performed += i => onMovement?.Invoke(i.ReadValue<Vector2>());

            inputActions.GeneralControls.Interaction.performed += i => onInteraction?.Invoke();
        }

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void EnableBoyControls()
    {
        inputActions.BoyControls.Enable();

        inputActions.BoyControls.Jump.performed += i => onJump?.Invoke();
        inputActions.BoyControls.Sprint.performed += i => onSprint?.Invoke(i.ReadValue<float>());
        inputActions.BoyControls.Dash.performed += i => onDash?.Invoke();

        inputActions.BoyControls.Attack.performed += i => onAttack?.Invoke();

        inputActions.BoyControls.EnterMech.performed += i => onEnterMech?.Invoke();
    }

    public void DisableBoyControls()
    {
        inputActions.BoyControls.Disable();
    }

    public void EnableMechControls()
    {
        inputActions.MechControls.Enable();

        inputActions.MechControls.ExitMech.performed += i => onExitMech?.Invoke();
        inputActions.MechControls.OverloadCharge.performed += i => onAbilityCharge?.Invoke();
        inputActions.MechControls.OverloadFlashlight.performed += i => onAbilityFlashlight?.Invoke();

    }

    public void DisableMechControls()
    {
        inputActions.MechControls.Disable();
    }
    public void DisableAllControls()
    {
        inputActions.MechControls.Disable();
        inputActions.BoyControls.Disable();
    }
}
