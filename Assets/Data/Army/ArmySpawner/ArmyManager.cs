using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ArmyManager : MyBehaviour
{
    [SerializeField] protected List<SoliderCtrl> enemySoliderAlive;
    public List<SoliderCtrl> EnemySoliders => enemySoliderAlive;
    [SerializeField] protected List<TowerCtrl> enemyTowerAlive;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyTower();
    }
    protected virtual void LoadEnemyTower()
    {
        if (this.enemySoliderAlive.Count > 0) return;
        TowerCtrl[] towers = GetComponentsInChildren<TowerCtrl>();
        this.enemyTowerAlive = towers.ToList();
        Debug.LogWarning(gameObject.name + " LoadTowerCtrl", gameObject);
    }
    public virtual void RemoveTower(TowerCtrl ctrl)
    {
        this.enemyTowerAlive.Remove(ctrl);
        this.CheckEnemyGate();
    }
    protected virtual void CheckEnemyGate()
    {
        if (this.enemyTowerAlive.Any()) return;
        //this.enemyGateCtrl.DamageReceiver.gameObject.SetActive(true);
    }
    public virtual void AddEnemy(SoliderCtrl enemy)
    {
        this.enemySoliderAlive.Add(enemy);
    }
    protected virtual void RemoveDeadOne()
    {
        foreach (SoliderCtrl enemyCtrl in this.enemySoliderAlive)
        {
            if (enemyCtrl.DamageReceiver.IsDead())
            {
                this.enemySoliderAlive.Remove(enemyCtrl);
                return;
            }
        }
    }
    public virtual void KillAllEnemy()
    {
        foreach (ArmyCtrl enemyCtrl in enemySoliderAlive)
        {
            enemyCtrl.DamageReceiver.Receive(500);
        }
    }
}
