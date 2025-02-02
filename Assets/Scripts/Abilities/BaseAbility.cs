using System.Threading.Tasks;
using UnityEngine;

public class BaseAbility : MonoBehaviour
{
    protected MechAbilityHandler mechAbilityHandler;
    protected ScriptableAbility data;

    //* MARK:Stats
    protected float abilityDuration;
    private AbilityIcon abilityIcon;
    public AbilityIcon AbilityIcon { set => abilityIcon = value; }
    bool inExecute;
    public bool InExecute { get => inExecute; }
    bool inCoolDown;
    public bool InCoolDown { get => inCoolDown; }

    public delegate void OnExecute();
    public OnExecute onExecute;


    public void Initialize(MechAbilityHandler _mechAbilityHandler, ScriptableAbility _data)
    {
        mechAbilityHandler = _mechAbilityHandler;
        data = _data;

        abilityDuration = data.duration;

        //onExecute += TryExecute;
    }
    public virtual void TryExecute()
    {
        if (inExecute)
            return;

        Execute();
    }

    protected virtual async Task Execute()
    {
        abilityIcon.ExecuteEffect();
    }

    protected virtual async Task CooldownTimer()
    {
        inCoolDown = true;
        var end = abilityDuration;

        while (0 < end)
        {
            end -= Time.deltaTime;
            await Task.Yield();
        }

        inCoolDown = false;
    }
}
