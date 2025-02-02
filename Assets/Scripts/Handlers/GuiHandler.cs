using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GuiHandler : MonoBehaviour
{
    PlayerController playerController;
    public PlayerController PlayerController { get => playerController; }
    [Header("Boy GUI")]
    [SerializeField] GameObject boyGUI;
    [SerializeField] Slider boyHealthSlider;
    [Space(5f)]
    [Header("Mech GUI")]
    [SerializeField] GameObject mechGUI;
    [Header("Mech Stats")]
    [SerializeField] Slider mechHealthSlider;
    [Header("Mech Abilities")]
    [SerializeField] Transform iconsContainer;
    // [SerializeField] AbilityCharge

    public delegate void OnOverchargeAbility();
    public OnOverchargeAbility onOverchargeAbility;

    public void Initialize(PlayerController _playerController)
    {
        playerController = _playerController;

        // Suscripción delegados

    }

    #region GUI - BOY

    public void ShowBoyGui()
    {
        boyGUI.SetActive(true);
    }
    public void HideBoyGui()
    {
        boyGUI.SetActive(false);
    }

    public void SetMaxSlider(Slider slider, int value)
    {
        slider.maxValue = value;
    }

    public void UpdateSlider(Slider slider, int newValue)
    {
        slider.value = newValue;
    }

    #endregion

    #region GUI-MECH
    public void ShowMechGui()
    {
        mechGUI.SetActive(true);
    }
    public void HideMechGui()
    {
        mechGUI.SetActive(false);
    }

    public void AddNewAbility(AbilityIcon abilityIcon)
    {
        abilityIcon.transform.SetParent(iconsContainer);
        //Instantiate(scriptableAbility.iconPrefab.gameObject, iconsContainer.transform);
    }


    #endregion
}