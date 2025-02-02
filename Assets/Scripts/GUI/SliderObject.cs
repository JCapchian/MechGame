using UnityEngine;
using UnityEngine.UI;

public class SliderObject : MonoBehaviour
{
    float Value;
    [SerializeField] Slider slider;

    public void SetMaxSliderValue(float newMax)
    {
        slider.maxValue = newMax;
    }

    public void UpdateSlider(float newValue)
    {
        slider.value = newValue;
    }
}