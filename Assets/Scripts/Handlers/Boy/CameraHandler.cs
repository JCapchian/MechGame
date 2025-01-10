using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    PlayerController playerController;

    [Header("Stats")]
    [SerializeField] Transform focusPoint;
    [SerializeField] Vector3 offset;
    [SerializeField] Vector3 velocity;
    [SerializeField] float damping;

    public void Initialize(PlayerController _playerController)
    {
        playerController = _playerController;
    }

    public void Handle()
    {
        HandleCamera();
    }

    void HandleCamera()
    {
        Vector3 movePosition = focusPoint.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }

    public void ChangeTarget(Transform newTarget)
    {
        focusPoint = newTarget;
    }
}
