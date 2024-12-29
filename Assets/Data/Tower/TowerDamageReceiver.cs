using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerDamageReceiver : ArmyDamageReceiver
{
    private void OnEnable()
    {
        this.currentHP = 100;
        this.maxHP = 100;
    }
    protected override void OnDead()
    {
        this.ctrl.Rada.RemoveTarget();
        transform.parent.gameObject.SetActive(false);

        TowerCtrl tower = (TowerCtrl)ctrl;
        tower.Ctrl.ArmyManager.RemoveTower(tower);

        InventoriesManager.Instance.AddItem(ItemCode.Gold, 30);
    }

    protected override void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<CapsuleCollider>();
        CapsuleCollider capsuleCollider = (CapsuleCollider)this._collider;
        capsuleCollider.radius = 0.6f;
        capsuleCollider.height = 4;
        capsuleCollider.center = new Vector3(0, 0, 0);
        capsuleCollider.isTrigger = true;
        Debug.LogWarning(gameObject.name + "LoadCapsuleCollider", gameObject);
    }
}
