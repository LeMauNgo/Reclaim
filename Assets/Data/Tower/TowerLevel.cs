using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLevel : LevelAbstract
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
        Debug.Log(transform.name + ": LoadTowerCtrl", gameObject);
    }


    //protected override int GetCurrentGold()
    //{
    //    throw new System.NotImplementedException();
    //}

    //protected override bool DeductGold(int exp)
    //{
    //    throw new System.NotImplementedException();
    //}
}
