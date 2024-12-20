using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarCtrl : MyBehaviour
{
    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageReceiver();
    }
    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<DamageReceiver>();
        Debug.LogWarning(gameObject.name +" LoadDamageReceiver", gameObject);
    }
}
