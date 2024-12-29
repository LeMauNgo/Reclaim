using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider))]
public class MyGateDamageReceiver : DamageReceiver
{
    [SerializeField] protected CapsuleCollider capsuleCollider;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
    }
    private void OnEnable()
    {
        this.currentHP = 200;
        this.maxHP = 200;
    }
    protected override void LoadCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = transform.GetComponent<CapsuleCollider>();
        this.capsuleCollider.radius = 3f;
        this.capsuleCollider.height = 10;
        this.capsuleCollider.center = new Vector3(0, 0, -1);
        this.capsuleCollider.isTrigger = true;
        this.capsuleCollider.direction = 0;
        Debug.LogWarning(gameObject.name + "LoadCapsuleCollider", gameObject);
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
}
