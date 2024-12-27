using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(Collider))]
public abstract class ArmyDamageReceiver : DamageReceiver
{
    [SerializeField] protected Collider _collider;
    [SerializeField] protected ArmyCtrl ctrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadCtrl();
    }
    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponentInParent<ArmyCtrl>();
        Debug.Log(gameObject.name + "LoadCtrl", gameObject);
    }
    protected abstract void LoadCollider();
    //{
    //    //if (this._collider != null) return;
    //    //this._collider = transform.GetComponent<Collider>();
    //    ////this._collider.radius = 0.3f;
    //    ////this._collider.height = 2;
    //    ////this._collider.center = new Vector3(0, 1, 0);
    //    //this._collider.isTrigger = true;
    //    //Debug.LogWarning(gameObject.name + "LoadCapsuleCollider", gameObject);
    //}
    protected override void OnDead()
    {
        //this.ctrl.Animator.SetBool("IsDeath", this.isDead);
        this._collider.enabled = false;
        this.ctrl.Rada.RemoveTarget();
        Invoke(nameof(DoDespawn), 5);

        //ItemDropSpawnerCtrl.Instance.DropMany(ItemCode.Gold, transform.position, 10);
        //ItemDropSpawnerCtrl.Instance.DropMany(ItemCode.Wand, transform.position, 1);
        //InventoriesManager.Instance.AddItem(ItemCode.PlayerExp, 1);
    }
    protected virtual void DoDespawn()
    {
        this.ctrl.Despawn.DoDespawn();
    }
    protected override void Rebone()
    {
        base.Rebone();
        this._collider.enabled = true;
        this.SetPosition();
    }
    protected override void OnHurt()
    {
        //throw new System.NotImplementedException();
    }
    protected virtual void SetPosition()
    {
        if(this.ctrl.GetTypeArmy() == ArmyType.Enemy)
        {
            transform.parent.position = new Vector3(42, 0, 39);
        }
        else
        {
            transform.parent.position = new Vector3(-42, 0, -39);
        }
    }
}
