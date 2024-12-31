using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class SliderAbstact : MyBehaviour
{
    [SerializeField] protected Slider slider;

    private void Start()
    {
        this.slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.Log(transform.name + ": LoadSlider", gameObject);
    }

    protected abstract void OnSliderValueChanged(float value);
}
