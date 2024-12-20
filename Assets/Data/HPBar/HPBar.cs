using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class HPBar : MyBehaviour
{
    [SerializeField] protected Slider slider;
    [SerializeField] protected HPBarCtrl ctrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHPbarCtrl();
        this.LoadSliderBar();
    }
    protected virtual void LoadSliderBar()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.LogWarning(gameObject.name + " LoadSliderBar", gameObject);
    }
    protected virtual void LoadHPbarCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponentInParent<HPBarCtrl>();
        Debug.LogWarning(gameObject.name + " LoadHPbarCtrl", gameObject);
    }
    private void Update()
    {
        this.UpDateHPBar();
    }
    protected virtual void UpDateHPBar()
    {
        this.slider.value = ctrl.DamageReceiver.HPRatio();
    }
} 
