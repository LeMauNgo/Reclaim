using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerManager : MyBehaviour
{
    [SerializeField] protected List<TowerCtrl> ctrls;
    [SerializeField] protected EnemyGateCtrl enemyGateCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTowerCtrl();
        this.LoadEnemyGateCtrl();
    }
    protected virtual void LoadEnemyGateCtrl()
    {
        if (this.enemyGateCtrl != null) return;
        this.enemyGateCtrl = FindObjectOfType<EnemyGateCtrl>();
        Debug.LogWarning(gameObject.name + " LoadEnemyGateCtrl", gameObject);
    }
    protected virtual void LoadTowerCtrl()
    {
        if (this.ctrls.Count > 0) return;
        TowerCtrl[] towers = GetComponentsInChildren<TowerCtrl>();
        this.ctrls = towers.ToList();
        Debug.LogWarning(gameObject.name + " LoadTowerCtrl", gameObject);
    }
    public virtual void RemoveTower(TowerCtrl ctrl)
    {
        this.ctrls.Remove(ctrl);
        this.CheckEnemyGate();
    }
    protected virtual void CheckEnemyGate()
    {
        if (this.ctrls.Any()) return;
        this.enemyGateCtrl.DamageReceiver.gameObject.SetActive(true);
    }
}
