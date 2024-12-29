using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class ArmyDamageReceiver : DamageReceiver
{
    [SerializeField] protected Collider _collider;
    [SerializeField] protected ArmyCtrl ctrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCtrl();
    }
    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponentInParent<ArmyCtrl>();
        Debug.Log(gameObject.name + "LoadCtrl", gameObject);
    }
    protected override void OnDead()
    {
        //this.ctrl.Animator.SetBool("IsDeath", this.isDead);
        this._collider.enabled = false;
        this.ctrl.Rada.RemoveTarget();
        Invoke(nameof(DoDespawn), 5);
    }
    protected virtual void DoDespawn()
    {
        this.ctrl.Despawn.DoDespawn();
    }
    protected override void Rebone()
    {
        base.Rebone();
        this._collider.enabled = true;
        //this.SetPosition();
    }
    protected override void OnHurt()
    {
        //throw new System.NotImplementedException();
    }
    protected virtual void SetPosition()
    {
        if(this.ctrl.GetTypeArmy() == ArmyType.Friendly)
        {
            transform.parent.position = new Vector3(-42, 0, -39);
        }
        else
        {
            transform.parent.position = new Vector3(42, 0, 39);
        }
    }
}
