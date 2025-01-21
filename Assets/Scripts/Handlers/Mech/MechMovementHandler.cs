using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;

public class MechMovementHandler : BaseStateMachine<MechMovementStates>
{
    PlayerController playerController;
    InputManager inputManager;

    #region Internal Variables
    Vector2 currentMovementAxi;
    public Vector2 CurrentMovementAxi { get => currentMovementAxi; }
    Vector3 currentMousePosition;
    public Vector3 CurrentMouseAxi { get => currentMovementAxi; }

    bool isGrounded;
    public bool IsGrounded { get => isGrounded; }
    float currentVelocity;
    #endregion

    [Header("Components")]
    [SerializeField] Rigidbody rigid;


    [Space(5f)]
    [Header("Stats")]
    [SerializeField] float groundDistance;

    [Space(2f)]
    [Header("Movement")]
    [SerializeField] float walkSpeedLimit;
    public float WalkSpeedLimit { get => walkSpeedLimit; }
    [SerializeField][Range(5f, 10f)] float walkModifier;
    public float WalkModifier { get => walkModifier; }
    [SerializeField] float runSpeedLimit;
    public float RunSpeedLimit { get => runSpeedLimit; }
    [SerializeField][Range(15f, 20f)] float runModifier;
    public float RunModifier { get => runModifier; }
    [SerializeField] float runDuration;
    public float RunDuration { get => runDuration; }

    [Space(2f)]
    [Header("Dash")]
    [SerializeField][Range(0.1f, 0.5f)] float dashDuration;
    public float DashDuration { get => dashDuration; }
    [SerializeField][Range(50f, 100f)] float dashModifier;
    public float DashModifier { get => dashModifier; }
    [SerializeField] float dashSpeedLimit;
    public float DashSpeedLimit { get => dashSpeedLimit; }

    public void Initialize(PlayerController _playerController)
    {
        playerController = _playerController;
        inputManager = playerController.InputManager;

        inputManager.onMovement += GetMovementAxis;
        inputManager.onDash += TryDashing;

        LoadStates();
    }

    protected override void LoadStates()
    {
        dictionaryStates = new Dictionary<MechMovementStates, BaseState<MechMovementStates>>();

        dictionaryStates.Add(MechMovementStates.Idle, new MechIdleState(MechMovementStates.Idle, this));
        dictionaryStates.Add(MechMovementStates.Move, new MechMoveState(MechMovementStates.Move, this));

        currentState = dictionaryStates[MechMovementStates.Idle];
    }

    public void ActiveMovement()
    {

    }

    public void DeactivateMovement()
    {

    }

    public void HandleMovement()
    {
        currentState.OnFixedUpdate(this);
        GroundCheck();
        //RotatePlayerModel();
    }

    public void GetMovementAxis(Vector2 _currentMovementAxi)
    {
        currentMovementAxi = _currentMovementAxi;
    }
    public void GetMouseAxis(Vector2 _currentMouseAxi)
    {
        //Debug.Log(_currentMouseAxi);

        currentMousePosition = Camera.main.ScreenToWorldPoint(_currentMouseAxi);
        currentMousePosition.z = 0;
        //currentMouseAxi = _currentMouseAxi;
    }

    public void RotatePlayerModel()
    {
        if (!isGrounded)
            return;

        // Vector3 lookAtPos = currentMouseAxi;
        // lookAtPos.z = transform.position.z - Camera.main.transform.position.z;
        // transform.up = lookAtPos - transform.position;

        //var lookAtPos = currentMouseAxi - rigid.position;


        // float angle = Mathf.Atan2(
        //     playerController.transform.position.y - currentMousePosition.y,
        //     playerController.transform.position.x - currentMousePosition.x)
        //     * Mathf.Rad2Deg;
        // Debug.Log(angle);
        // playerController.transform.Rotate(0, angle, 0);

        if (currentMovementAxi.magnitude != 0)
        {
            var relative = (playerController.transform.position + new Vector3(currentMovementAxi.x, 0, currentMovementAxi.y)) - playerController.transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);


            playerController.transform.rotation = Quaternion.RotateTowards(playerController.transform.rotation, rot, 5f * Time.deltaTime);

        }
        //playerController.transform.Rotate(new Vector3(0, angle, 0) * Time.deltaTime, Space.World);

        //rigid.rotation = angle;
        //rigid.MoveRotation(angle);

        // playerController.transform.LookAt(currentMouseAxi);
        //playerController.transform.Rotate(0, currentMouseAxi.y, 0);

        // var rot = Quaternion.LookRotation(currentMouseAxi, Vector3.up);
        // transform.rotation = Quaternion.RotateTowards(playerController.transform.rotation, rot, movementSpeed * Time.deltaTime);
    }

    #region Velocity Function
    public void ResetVelocity()
    {
        currentVelocity = 0;
    }
    public void ActivateGravity()
    {
        rigid.useGravity = true;
    }
    public void DeactivateGravity()
    {
        rigid.useGravity = false;
    }

    public void Move(float speedModifier, float speedLimit)
    {
        if (!isGrounded)
            return;

        currentVelocity += Time.deltaTime * speedModifier;

        if (currentVelocity >= speedLimit)
            currentVelocity = speedLimit;

        Vector3 MoveVector = transform.TransformDirection(currentMovementAxi.x, 0, currentMovementAxi.y) * currentVelocity;
        rigid.linearVelocity = MoveVector;
    }

    #endregion

    #region Ability Function
    public void TryDashing()
    {
        if (!isGrounded)
            return;

        // Si no se mueve, no hay dash
        if (currentMovementAxi.magnitude == 0)
            return;

        // SwitchState(MovementStates.Dashing);
    }
    #endregion

    void GroundCheck()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        isGrounded = Physics.Raycast(ray, groundDistance);
    }

}
