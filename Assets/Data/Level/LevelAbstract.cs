using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelAbstract : MyBehaviour
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
        Debug.LogWarning(gameObject.name + " LoadTowerManager", gameObject);
    }
}
