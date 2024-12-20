using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerDamageReceiver : DamageReceiver
{
    [SerializeField] protected CapsuleCollider capsuleCollider;
    [SerializeField] protected PlayerCtrl ctrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCapsuleCollider();
        this.LoadSoliderCtrl();
    }
    private void OnEnable()
    {
        this.currentHP = 100;
        this.maxHP = 100;
    }
    protected virtual void LoadSoliderCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponentInParent<PlayerCtrl>();
        Debug.Log(gameObject.name + "LoadSoliderCtrl", gameObject);
    }
    protected virtual void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = transform.GetComponent<CapsuleCollider>();
        this.capsuleCollider.radius = 0.2f;
        this.capsuleCollider.height = 1.8f;
        this.capsuleCollider.center = new Vector3(0, 0.9f, 0);
        this.capsuleCollider.isTrigger = true;
        Debug.LogWarning(gameObject.name + "LoadCapsuleCollider", gameObject);
    }
    protected override void OnDead()
    {
        //this.ctrl.Animator.SetBool("IsDeath", this.isDead);
        //this.capsuleCollider.enabled = false;
        if (!GameManager.Instance.IsPlaying()) return;
        transform.parent.gameObject.SetActive(false);
        UIManager.Instance.UICenter.ShowUiCenter("Lose");
        GameManager.Instance.SetGamePlay(false);
        //Invoke(nameof(DoDespawn), 5);

        //ItemDropSpawnerCtrl.Instance.DropMany(ItemCode.Gold, transform.position, 10);
        //ItemDropSpawnerCtrl.Instance.DropMany(ItemCode.Wand, transform.position, 1);
        //InventoriesManager.Instance.AddItem(ItemCode.PlayerExp, 1);
    }
    //protected virtual void DoDespawn()
    //{
    //    this.ctrl.Despawn.DoDespawn();
    //}
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
