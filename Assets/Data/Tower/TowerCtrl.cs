using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerCtrl : EnemyCtrl
{
    //[SerializeField] protected TowerRada towerRada;
    //public TowerRada TowerRada => towerRada;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;
    [SerializeField] protected TowerShooting towerShooting;
    public TowerShooting TowerShooting => towerShooting;
    //[SerializeField] protected TowerLevel level;
    //public TowerLevel Level => level;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //this.LoadTowerRada();
        this.LoadRotator();
        this.LoadTowerShooting();
        //this.LoadTowerLevel();
    }
    //protected virtual void LoadTowerRada()
    //{
    //    if (this.towerRada != null) return;
    //    this.towerRada = GetComponentInChildren<TowerRada>();
    //    Debug.LogWarning(gameObject.name + "LoadTowerRada", gameObject);
    //}
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
    //protected virtual void LoadTowerLevel()
    //{
    //    if (this.level != null) return;
    //    this.level = GetComponentInChildren<TowerLevel>();
    //    Debug.LogWarning(gameObject.name + "LoadTowerLevel", gameObject);
    //}

    public override string GetName()
    {
        return "Tower";
    }
}
