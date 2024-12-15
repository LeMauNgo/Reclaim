using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbstract : MyBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log("LoadEnemyCtrl", gameObject);
    }
}
