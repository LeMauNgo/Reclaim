using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectFlyCtrl : EffectCtrl
{
    [SerializeField] protected FlyToTarget flyToTarget;
    public FlyToTarget FlyToTarget => flyToTarget;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadFlyToTarget();
    }

    protected virtual void LoadFlyToTarget()
    {
        if (this.flyToTarget != null) return;
        this.flyToTarget = GetComponentInChildren<FlyToTarget>();
        Debug.Log(transform.name + ": LoadFlyToTarget", gameObject);
    }
}
