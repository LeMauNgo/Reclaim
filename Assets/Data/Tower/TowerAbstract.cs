using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAbstract : MyBehaviour
{
    [SerializeField] protected TowerCtrl towerCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTowerCtrl();
    }
    protected virtual void LoadTowerCtrl()
    {
        if (this.towerCtrl != null) return;
        this.towerCtrl = GetComponentInParent<TowerCtrl>();
        Debug.LogWarning(gameObject.name + "Load TowerCtrl", gameObject);
    }
}
