using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtTowerLevel : TxtLevel
{
    [SerializeField] protected TowerManager towerManager;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTowerManager();
    }

    protected virtual void LoadTowerManager()
    {
        if (this.towerManager != null) return;
        this.towerManager = GetComponentInParent<TowerManager>();
        Debug.Log(transform.name + ": LoadTowerManager", gameObject);
    }

    protected override string GetLevel()
    {
        return this.towerManager.CurrentLevel.ToString();
    }
}
