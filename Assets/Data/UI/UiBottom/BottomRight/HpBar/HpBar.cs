using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MyBehaviour
{
    [SerializeField] protected Slider sliderBar;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSliderBar();
    }
    protected virtual void LoadSliderBar()
    {
        if (this.sliderBar != null) return;
        this.sliderBar = GetComponent<Slider>();
        Debug.LogWarning(gameObject.name + " LoadSliderBar", gameObject);
    }
    private void Update()
    {
        this.UpdateSliderBar();
    }
    protected virtual void UpdateSliderBar()
    {
        this.sliderBar.value = PlayerManager.Instance.PlayerCtrl.PlayerDamageReceiver.HPRatio();
    }
}
