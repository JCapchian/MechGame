using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Rendering;

public class BoyAbilityHandler : MonoBehaviour
{
    BoyController boyController;

    BoyMovementHandler boyMovementHandler;

    [Header("Abilities")]
    [SerializeField] BaseAbility basicAttack;

    [SerializeField] float combatModeDuration;
    [SerializeField] bool inCombatMode;
    public bool InCombatMode { get => inCombatMode; }



    public void Initialize(BoyController _boyController)
    {
        boyController = _boyController;

        boyMovementHandler = boyController.BoyMovementHandler;

        boyController.PlayerController.InputManager.onAttack += TryAttack;
    }


    public void TryAttack()
    {
        if (!boyController.BoyMovementHandler.IsGrounded)
            return;

        Attack();
    }

    void Attack()
    {
        basicAttack.Execute();

        TryCombatMode();
    }

    public void TryCombatMode()
    {
        if (inCombatMode)
            return;

        EnterCombatMode();
    }

    public void EnterCombatMode()
    {
        inCombatMode = true;

        StartCoroutine(CombatModeTimer());
        //Debug.Log("Entro modo de combate");
    }

    IEnumerator CombatModeTimer()
    {
        yield return new WaitForSeconds(combatModeDuration);
        inCombatMode = false;
        //return default;
    }
}
