using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider))]
public class SoliderDamageReceiver : DamageReceiver
{
    [SerializeField] protected CapsuleCollider capsuleCollider;
    [SerializeField] protected SoliderCtrl ctrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCapsuleCollider();
        this.LoadSoliderCtrl();
    }
    protected virtual void LoadSoliderCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponentInParent<SoliderCtrl>();
        Debug.Log(gameObject.name + "LoadSoliderCtrl", gameObject);
    }
    protected virtual void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = transform.GetComponent<CapsuleCollider>();
        this.capsuleCollider.radius = 0.3f;
        this.capsuleCollider.height = 2;
        this.capsuleCollider.center = new Vector3(0, 1, 0);
        this.capsuleCollider.isTrigger = true;
        Debug.LogWarning(gameObject.name + "LoadCapsuleCollider", gameObject);

    }
    protected override void OnDead()
    {
        this.ctrl.Animator.SetBool("IsDeath", this.isDead);
        this.capsuleCollider.enabled = false;
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
        this.capsuleCollider.enabled = true;
    }
    protected override void OnHurt()
    {
        //throw new System.NotImplementedException();
    }
}
