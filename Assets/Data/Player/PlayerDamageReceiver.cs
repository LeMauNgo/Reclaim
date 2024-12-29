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
    protected override void OnDead()
    {
        if (!GameManager.Instance.IsPlaying()) return;
        transform.parent.gameObject.SetActive(false);
        UIManager.Instance.UICenter.ShowUiCenter("Lose");
        GameManager.Instance.SetGamePlay(false);
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

    protected override void LoadCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = transform.GetComponent<CapsuleCollider>();
        this.capsuleCollider.radius = 0.2f;
        this.capsuleCollider.height = 1.8f;
        this.capsuleCollider.center = new Vector3(0, 0.9f, 0);
        this.capsuleCollider.isTrigger = true;
        Debug.LogWarning(gameObject.name + "LoadCapsuleCollider", gameObject);
    }
}
