using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerCtrl : ArmyCtrl
{
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;
    [SerializeField] protected TowerShooting towerShooting;
    public TowerShooting TowerShooting => towerShooting;
    [SerializeField] protected TowerManager towerManager;
    public TowerManager TowerManager => towerManager;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRotator();
        this.LoadTowerShooting();
        this.LoadTowerManager();
    }
    protected virtual void LoadTowerManager()
    {
        if (this.towerManager != null) return;
        this.towerManager = GetComponentInParent<TowerManager>();
        Debug.LogWarning(gameObject.name + "LoadTowerManager", gameObject);
    }
    protected virtual void LoadRotator()
    {
        if(this.rotator != null) return;
        this.rotator = transform.Find("Model").Find("Rotator");
        Debug.LogWarning(gameObject.name + "LoadRotator", gameObject);
    }
    protected virtual void LoadTowerShooting()
    {
        if (this.towerShooting != null) return;
        this.towerShooting = GetComponentInChildren<TowerShooting>();
        Debug.LogWarning(gameObject.name + "LoadTowerShooting", gameObject);
    }
    public override string GetName()
    {
        return "Tower";
    }
}
