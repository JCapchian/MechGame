using UnityEngine;

public class BaseAbility : MonoBehaviour
{
    protected MechAbilityHandler mechAbilityHandler;
    public void Assign(MechAbilityHandler _mechAbilityHandler) { mechAbilityHandler = _mechAbilityHandler; }
    public virtual void Execute() { }
}
