using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ArmyManager : MyBehaviour
{
    [SerializeField] protected List<ArmyCtrl> armyAlive;
    public List<ArmyCtrl> ArmyAlive => armyAlive;
    [SerializeField] protected SoliderManager soliderManager;
    public SoliderManager SoliderManager => soliderManager;
    [SerializeField] protected TowerManager towerManager;
    public TowerManager TowerManager => towerManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSoliderManager();
        this.LoadTowerManager();
        this.LoadArrmy();
    }
    protected virtual void LoadArrmy()
    {
        if (this.armyAlive.Count > 0) return;
        ArmyCtrl[] armyCtrls = GetComponentsInChildren<ArmyCtrl>();
        this.armyAlive = armyCtrls.ToList();
        Debug.LogWarning(gameObject.name + " LoadArrmy", gameObject);

    }
    protected virtual void LoadSoliderManager()
    {
        if (this.soliderManager != null) return;
        this.soliderManager = GetComponent<SoliderManager>();
        Debug.LogWarning(gameObject.name + " LoadSoliderManager", gameObject);
    }    
    protected virtual void LoadTowerManager()
    {
        if (this.towerManager != null) return;
        this.towerManager = GetComponent<TowerManager>();
        Debug.LogWarning(gameObject.name + " LoadTowerManager", gameObject);
    }
    public virtual void AddEnemy(ArmyCtrl army)
    {
        this.armyAlive.Add(army);
        this.soliderManager.LoadSolider();
    }
    private void FixedUpdate()
    {
        this.RemoveDeadOne();
    }
    public virtual void KillAllEnemy()
    {
        foreach (ArmyCtrl enemyCtrl in armyAlive)
        {
            enemyCtrl.DamageReceiver.Receive(500);
        }
    }
    protected virtual void RemoveDeadOne()
    {
        foreach (ArmyCtrl armyCtrl in this.armyAlive)
        {
            if (armyCtrl.DamageReceiver.IsDead())
            {
                this.armyAlive.Remove(armyCtrl);
                this.towerManager.LoadEnemyTower();
                this.soliderManager.LoadSolider();
                return;
            }
        }
    }













}
