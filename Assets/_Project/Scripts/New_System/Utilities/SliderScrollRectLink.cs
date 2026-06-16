using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

[ExecuteAlways]
public class SliderScrollRectLink : MonoBehaviour
{
    public ScrollRect scrollRect;
    public Slider slider;

    private bool sliderToScroll = false;
    private bool scrollToSlider = false;

    private void OnEnable()
    {
        if(slider != null)
        {
            slider.onValueChanged.AddListener(OnSliderChanged);
            scrollRect.onValueChanged.AddListener(OnScrollRectChanged);
        }
    }
    private void OnDisable()
    {
        if (slider != null)
        {
            slider.onValueChanged.RemoveListener(OnSliderChanged);
            scrollRect.onValueChanged.RemoveListener(OnScrollRectChanged);
        }
    }

    void OnSliderChanged(float pos)
    {
        if (scrollToSlider)
        {
            scrollToSlider = false;
            return;
        }
        sliderToScroll = true;
        scrollRect.verticalNormalizedPosition = 1f - pos;
    }

    void OnScrollRectChanged(Vector2 value)
    {
        if (sliderToScroll)
        {
            sliderToScroll = false;
            return;
        }
        scrollToSlider = true;
        slider.value = 1f - value.y;
    }
}
