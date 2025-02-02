using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class MechAbilityHandler : MonoBehaviour
{
    //* MARK: Controllers
    MechController mechController;
    PlayerController playerController;

    //* MARK: Managers
    InputManager inputManager;

    //* MARK: Handlers
    GuiHandler guiHandler;


    //* MARK: Handlers
    [Header("Abilities Data")]
    [SerializeField] List<BaseAbility> abilities;
    [SerializeField] Transform abilitiesContainer;

    [SerializeField] ScriptableAbility overloadChargeData;
    BaseAbility overloadChargeAbility;
    [SerializeField] ScriptableAbility overloadedFlashlightData;
    BaseAbility overloadedFlashlightAbility;

    public void Initialize(MechController _mechController)
    {
        mechController = _mechController;
        playerController = mechController.PlayerController;

        inputManager = playerController.InputManager;
        guiHandler = playerController.GuiHandler;

        inputManager.onAbilityCharge += TryOverloadedCharge;
        inputManager.onAbilityFlashlight += TryOverloadFlashlight;
    }

    #region Abilities Region
    public void InstallAbility(ScriptableAbility abilityToInstall)
    {
        var ability = PrefabUtility.InstantiatePrefab(abilityToInstall.ability, abilitiesContainer) as BaseAbility;
        var icon = Instantiate(abilityToInstall.iconPrefab);

        icon.Initialize(abilityToInstall);
        ability.Initialize(this, abilityToInstall);
        ability.AbilityIcon = icon;

        guiHandler.AddNewAbility(icon);
        abilities.Add(ability);
    }

    public void TryOverloadedCharge()
    {
        // Pregunta si tiene la habilidad guardad
        if (!overloadChargeAbility)
        {
            // Pregunta si tiene la habilidad
            overloadChargeAbility = CheckForAbility(overloadChargeData.abilityName);
            // Si lo que encontró esta vació no hace nada
            if (overloadChargeAbility == null)
            {
                return;
            }
            //guiHandler
        }

        // Otros chequeos
        if (overloadChargeAbility.InCoolDown)
            return;

        // Ejecuta la habilidad
        overloadChargeAbility.TryExecute();
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
            overloadedFlashlightAbility = CheckForAbility(overloadedFlashlightData.abilityName);
            // Si lo que encontró esta vació no hace nada
            if (overloadedFlashlightAbility == null)
                return;
        }

        // Otros chequeos



        // Ejecuto la habilidad
        overloadedFlashlightAbility.TryExecute();
    }

    public void OverloadFlashlight()
    {
        Debug.Log("Activo Overload Flashlight");
    }

    BaseAbility CheckForAbility(String name)
    {
        if (!abilities.Any())
            return null;

        foreach (var ability in abilities)
        {
            if (ability.name == name)
            {
                // ability.Initialize(this);
                return ability;
            }
        }
        return null;
    }
    #endregion
}
