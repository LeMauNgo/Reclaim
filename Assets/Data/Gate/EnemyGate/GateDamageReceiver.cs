using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider))]
public class GateDamageReceiver : DamageReceiver
{
    [SerializeField] protected CapsuleCollider _collider;
    private void OnEnable()
    {
        this.currentHP = 200;
        this.maxHP = 200;
    }
    protected override void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<CapsuleCollider>();
        CapsuleCollider capsuleCollider = (CapsuleCollider)this._collider;
        capsuleCollider.radius = 3f;
        capsuleCollider.height = 10;
        capsuleCollider.center = new Vector3(0, 0, -1);
        capsuleCollider.isTrigger = true;
        capsuleCollider.direction = 0;
        Debug.LogWarning(gameObject.name + "LoadCollider", gameObject);
    }
    protected override void OnDead()
    {
        if (!GameManager.Instance.IsPlaying()) return;
        transform.parent.gameObject.SetActive(false);
        UIManager.Instance.UICenter.ShowUiCenter("Win");
        GameManager.Instance.SetGamePlay(false);
        ArmySpawnerCtrl.Instance.ArmyManager.KillAllEnemy();
    }
    public override void Receive(int damage)
    {
        if(this.CanReceive() == false) return;
        base.Receive(damage);
    }
    protected virtual bool CanReceive()
    {
        return ArmySpawnerCtrl.Instance.ArmyManager.TowerManager.EnemyTowerAlive.Count == 0;
    }
    protected override void OnHurt()
    {
        //
    }
}
