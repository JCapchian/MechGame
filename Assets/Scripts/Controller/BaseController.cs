using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected PlayerController playerController;
    public PlayerController PlayerController { get => playerController; }

    #region Components
    [SerializeField] private GameObject characterModel;
    public GameObject CharacterModel { get => characterModel; }
    #endregion

    public virtual void Initialize(PlayerController _playerController) { playerController = _playerController; }
    public virtual void Disable() { }
    public virtual void EnableControls() { }
    public virtual void ControllerUpdate() { }
    public virtual void ControllerFixedUpdate() { }
    public virtual void ControllerLateUpdate() { }
}
