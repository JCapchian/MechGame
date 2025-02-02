using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
    [SerializeField] SliderObject loadingSlider;
    [SerializeField] Color normalColor;
    [SerializeField] Color executeColor;
    [SerializeField] Image icon;
    float cooldownDuration;
    float activeDuration;

    public void Initialize(ScriptableAbility data)
    {
        icon.sprite = data.icon;
        activeDuration = data.duration;
        cooldownDuration = data.cooldown;

        loadingSlider.SetMaxSliderValue(cooldownDuration);
    }

    public void ExecuteEffect()
    {
        //loadingSlider.UpdateSlider(cooldownDuration);
        ActiveEffect();
    }

    public async Task ActiveEffect()
    {
        icon.color = executeColor;

        var end = activeDuration;
        while (0 < end)
        {
            end -= Time.deltaTime;
            //loadingSlider.UpdateSlider(end);
            await Task.Yield();
        }
        icon.color = normalColor;
    }

    async

    public void CooldownEffect()
    {
        loadingSlider.UpdateSlider(cooldownDuration);
        TimerCooldown();
    }

    public async Task TimerCooldown()
    {
        var end = cooldownDuration;
        while (0 < end)
        {
            end -= Time.deltaTime;
            loadingSlider.UpdateSlider(end);
            await Task.Yield();
        }
    }
}
