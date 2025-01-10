using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;

public class BoyMovementHandler : BaseStateMachine<MovementStates>
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
    [Header("Jump")]
    [SerializeField] float jumpForce;

    [Space(2f)]
    [Header("Dash")]
    [SerializeField][Range(0.1f, 0.5f)] float dashDuration;
    public float DashDuration { get => dashDuration; }
    [SerializeField][Range(50f, 100f)] float dashModifier;
    public float DashModifier { get => dashModifier; }
    [SerializeField] float dashSpeedLimit;
    public float DashSpeedLimit { get => dashSpeedLimit; }
    [Space(2f)]
    [Header("Climbing")]
    [SerializeField] LayerMask climbLayer;
    [SerializeField][Range(0.5f, 1f)] float climbDetectionRange;
    [SerializeField] GameObject wallClimbing;
    public GameObject WallClimbing { get => wallClimbing; }
    [SerializeField] float climbSpeedModifier;
    public float ClimbSpeedModifier { get => climbSpeedModifier; }
    [SerializeField] float climbSpeedLimit;
    public float ClimbSpeedLimit { get => climbSpeedLimit; }
    [SerializeField] float climbExitJumpForce;


    public void Initialize(PlayerController _playerController)
    {
        playerController = _playerController;
        inputManager = playerController.InputManager;

        inputManager.onMovement += GetMovementAxis;
        inputManager.onMouseMovement += GetMouseAxis;
        inputManager.onJump += TryJump;
        inputManager.onSprint += TryRunning;
        inputManager.onDash += TryDashing;

        LoadStates();
    }

    protected override void LoadStates()
    {
        dictionaryStates = new Dictionary<MovementStates, BaseState<MovementStates>>();

        dictionaryStates.Add(MovementStates.Idle, new IdleState(MovementStates.Idle, this));
        dictionaryStates.Add(MovementStates.Move, new MoveState(MovementStates.Move, this));
        dictionaryStates.Add(MovementStates.Run, new RunState(MovementStates.Run, this));
        dictionaryStates.Add(MovementStates.Dashing, new DashState(MovementStates.Dashing, this));
        dictionaryStates.Add(MovementStates.Jumping, new JumpingState(MovementStates.Jumping, this));
        dictionaryStates.Add(MovementStates.Climbing, new ClimbingState(MovementStates.Climbing, this));

        currentState = dictionaryStates[MovementStates.Idle];
    }

    public void HandleMovement()
    {
        currentState.OnFixedUpdate(this);
        GroundCheck();
        ClimbSurfaceCheck();
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


    public void TryRunning(float holdAction)
    {
        if (!isGrounded)
            return;

        if (holdAction == 1)
            SwitchState(MovementStates.Run);
        else
            SwitchState(MovementStates.Move);
    }

    #endregion

    #region Ability Function
    public void TryJump()
    {
        if (!isGrounded)
            return;


        SwitchState(MovementStates.Jumping);
    }
    public void Jump()
    {
        Vector3 JumpDirection = transform.up * jumpForce;
        rigid.AddForce(JumpDirection, ForceMode.Force);

    }

    public void TryDashing()
    {
        if (!isGrounded)
            return;

        // Si no se mueve, no hay dash
        if (currentMovementAxi.magnitude == 0)
            return;

        SwitchState(MovementStates.Dashing);
    }
    #endregion

    #region Climbing Functions

    public void ChangeClimbingInput()
    {
        inputManager.onJump -= TryJump;
        inputManager.onJump += JumpClimbExit;
    }

    public void ChangeMoveInput()
    {
        inputManager.onJump -= JumpClimbExit;
        inputManager.onJump += TryJump;
    }

    public void ClimbSurfaceCheck()
    {
        var colliders = Physics.OverlapSphere(transform.position, climbDetectionRange, climbLayer);
        if (colliders.Any())
        {
            if (wallClimbing == colliders[0].gameObject)
                return;
            Debug.Log(colliders[0]);
            wallClimbing = colliders[0].gameObject;
            SwitchState(MovementStates.Climbing);
        }
        else
        {
            if (wallClimbing == null)
                return;

            wallClimbing = null;
            SwitchState(MovementStates.Idle);
        }
    }

    public void Climb(float speedLimit)
    {
        // if (!isGrounded)
        //     return;

        Vector3 MoveVector = transform.TransformDirection(currentMovementAxi.x, currentMovementAxi.y, 0) * speedLimit;
        rigid.linearVelocity = MoveVector;
    }

    public void JumpClimbExit()
    {
        Vector3 JumpDirection = -transform.forward * climbExitJumpForce;
        rigid.AddForce(JumpDirection, ForceMode.Force);
    }

    #endregion

    void GroundCheck()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        isGrounded = Physics.Raycast(ray, groundDistance);
    }

}