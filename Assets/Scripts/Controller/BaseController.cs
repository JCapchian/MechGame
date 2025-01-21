using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected PlayerController playerController;
    public PlayerController PlayerController { get => playerController; }


    public virtual void Initialize(PlayerController _playerController) { playerController = _playerController; }
    public virtual void Disable() { }
    public virtual void EnableControls() { }
    public virtual void ControllerUpdate() { }
    public virtual void ControllerFixedUpdate() { }
    public virtual void ControllerLateUpdate() { }
}
