using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class MechAbilityHandler : MonoBehaviour
{
    InputManager inputManager;
    MechController mechController;
    [Header("Abilities")]
    [SerializeField] List<BaseAbility> abilities;

    [SerializeField] ScriptableAbility overloadChargeData;
    BaseAbility overloadChargeAbility;
    [SerializeField] ScriptableAbility overloadedFlashlightData;
    BaseAbility overloadedFlashlightAbility;

    public void Initialize(MechController _mechController)
    {
        mechController = _mechController;
        inputManager = mechController.PlayerController.InputManager;

        inputManager.onAbilityCharge += TryOverloadedCharge;
        inputManager.onAbilityFlashlight += TryOverloadFlashlight;
    }

    #region Upgrade Region

    public void InstallUpgrade(BaseAbility abilityToInstall)
    {
        abilities.Add(abilityToInstall);
    }
    #endregion

    #region Abilities Region

    public void TryOverloadedCharge()
    {
        Debug.Log("Over");
        // Chequeos si existe la habilidad

        // Pregunta si tiene la habilidad guardad
        if (!overloadChargeAbility)
        {
            // Pregunta si tiene la habilidad
            overloadChargeAbility = CheckForAbility(overloadChargeData);
            // Si lo que encontró esta vació no hace nada
            if (overloadChargeAbility == null)
                return;
        }

        // Otros chequeos



        // Ejecuta la habilidad
        overloadChargeAbility.Execute();
    }

    public void OverloadCharge()
    {
        Debug.Log("Activado Overload Charge");
    }

    public void TryOverloadFlashlight()
    {
        // Chequeos si existe la habilidad

        // Pregunta si tiene la habilidad guardad
        if (!overloadedFlashlightAbility)
        {
            // Pregunta si tiene la habilidad
            overloadedFlashlightAbility = CheckForAbility(overloadedFlashlightData);
            // Si lo que encontró esta vació no hace nada
            if (overloadedFlashlightAbility == null)
                return;
        }

        // Otros chequeos



        // Ejecuto la habilidad
        overloadedFlashlightAbility.Execute();
    }

    public void OverloadFlashlight()
    {
        Debug.Log("Activo Overload Flashlight");
    }

    BaseAbility CheckForAbility(ScriptableAbility scriptableAbility)
    {
        if (!abilities.Any())
            return null;

        foreach (var ability in abilities)
        {
            if (ability == scriptableAbility.ability)
            {
                ability.Assign(this);
                return ability;
            }
        }
        return null;
    }
    #endregion
}
