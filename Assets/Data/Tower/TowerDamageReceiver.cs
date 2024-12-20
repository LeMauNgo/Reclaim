using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerDamageReceiver : EnemyDamageReceiver
{
    private void OnEnable()
    {
        this.currentHP = 100;
        this.maxHP = 100;
    }
    protected override void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = transform.GetComponent<CapsuleCollider>();
        this.capsuleCollider.radius = 0.6f;
        this.capsuleCollider.height = 4;
        this.capsuleCollider.center = new Vector3(0, 0, 0);
        this.capsuleCollider.isTrigger = true;
        Debug.LogWarning(gameObject.name + "LoadCapsuleCollider", gameObject);
    }
    protected override void OnDead()
    {
        //this.ctrl.Animator.SetBool("IsDeath", this.isDead);
        //this.capsuleCollider.enabled = false;
        this.ctrl.EnemyRada.RemoveTarget();
        transform.parent.gameObject.SetActive(false);

        TowerCtrl tower = (TowerCtrl)ctrl;
        tower.TowerManager.RemoveTower(tower);
        //Invoke(nameof(DoDespawn), 5);

        //ItemDropSpawnerCtrl.Instance.DropMany(ItemCode.Gold, transform.position, 10);
        //ItemDropSpawnerCtrl.Instance.DropMany(ItemCode.Wand, transform.position, 1);
        //InventoriesManager.Instance.AddItem(ItemCode.PlayerExp, 1);
    }
    protected override void Rebone()
    {
        base.Rebone();
        this.capsuleCollider.enabled = true;
    }
}
