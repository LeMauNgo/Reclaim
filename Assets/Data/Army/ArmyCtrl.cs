using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ArmyCtrl : PoolObj
{
    [SerializeField] protected ArmyDamageReceiver damageReceiver;
    public ArmyDamageReceiver DamageReceiver => damageReceiver;
    [SerializeField] protected ArmySpawnerCtrl ctrl;
    public ArmySpawnerCtrl Ctrl => ctrl;
    [SerializeField] protected ArmyRada rada;
    public ArmyRada Rada => rada;
    [SerializeField] protected ArmyType type;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageReceiver();
        this.LoadRada();
        this.SetTypeArmy();
        this.LoadArmySpawnerCtrl();
    }
    protected virtual void LoadDamageReceiver()
    {
        if (damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<ArmyDamageReceiver>();
        Debug.Log("LoadAnimator", gameObject);
    }   
    protected virtual void LoadArmySpawnerCtrl()
    {
        if (ctrl != null) return;
        this.ctrl = GetComponentInParent<ArmySpawnerCtrl>();
        Debug.Log("LoadArmySpawnerCtrl", gameObject);
    }
    protected virtual void LoadRada()
    {
        if (this.rada != null) return;
        this.rada = GetComponentInChildren<ArmyRada>();
        Debug.Log("LoadRada", gameObject);
    }
    protected abstract void SetTypeArmy();
    public virtual ArmyType GetTypeArmy()
    {
       return this.type;
    }
}
