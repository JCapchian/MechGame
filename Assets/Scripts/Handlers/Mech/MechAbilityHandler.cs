using UnityEngine;
using UnityEngine.Rendering;

public class MechAbilityHandler : MonoBehaviour
{
    MechController mechController;
    public void Initialize(MechController _mechController)
    {
        mechController = _mechController;
    }

    #region Upgrade Region

    public void InstallUpgrade()
    {
        Debug.Log("Install Upgrade");
    }
    #endregion
}
