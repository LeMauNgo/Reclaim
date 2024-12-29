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
    public List<TowerCtrl> EnemyTowerAlive => enemyTowerAlive;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyTower();
    }
    protected virtual void LoadEnemyTower()
    {
        if (this.enemyTowerAlive.Count > 0) return;
        TowerCtrl[] towers = GetComponentsInChildren<TowerCtrl>();
        foreach (TowerCtrl tower in towers)
        {
            if(tower.GetTypeArmy() != ArmyType.Enemy) continue;
            this.enemyTowerAlive.Add(tower);
        }
        Debug.LogWarning(gameObject.name + " LoadEnemyTower", gameObject);
    }
    public virtual void RemoveTower(TowerCtrl ctrl)
    {
        this.enemyTowerAlive.Remove(ctrl);
    }
    public virtual void AddEnemy(SoliderCtrl enemy)
    {
        this.enemySoliderAlive.Add(enemy);
    }
    private void FixedUpdate()
    {
        this.RemoveDeadOne();
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
