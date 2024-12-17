using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public abstract class BulletDamageSender : DamageSender
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected EffectCtrl effectCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.effectCtrl != null) return;
        this.effectCtrl = GetComponentInParent<EffectCtrl>();
        Debug.Log(gameObject.name + "LoadBulletCtrl", gameObject);
    }
    protected override void LoadTriggerCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<Collider>();
        this.sphereCollider = (SphereCollider)this._collider;
        this._collider.isTrigger = true;
        this.sphereCollider.radius = 0.5f;
        Debug.Log(transform.name + ": LoadTriggerCollider", gameObject);
    }
    protected override DamageReceiver SendDamage(Collider collider)
    {
        if(!this.CanSendDamage(collider)) return null;
        DamageReceiver damageReceiver = base.SendDamage(collider);
        if (damageReceiver == null) return null;
        
        this.effectCtrl.Despawn.DoDespawn();
        return damageReceiver;
    }
    protected abstract bool CanSendDamage(Collider collider);
}
