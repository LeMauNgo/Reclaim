using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyPrefabs : PoolPrefabs<ArmyCtrl> 
{
    [SerializeField] protected List<ArmyCtrl> enemys;
    [SerializeField] protected List<ArmyCtrl> friendly;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemys();
        this.LoadFriendly();
    }
    protected virtual void LoadEnemys()
    {
        foreach (ArmyCtrl ctrl in this.prefabs)
        {
            if (ctrl.GetTypeArmy() != ArmyType.Enemy) continue;
            this.enemys.Add(ctrl);
        }
        Debug.LogWarning(gameObject.name + " LoadEnemys", gameObject);
    }
    protected virtual void LoadFriendly()
    {
        foreach (ArmyCtrl ctrl in this.prefabs)
        {
            if (ctrl.GetTypeArmy() != ArmyType.Ally) continue;
            this.friendly.Add(ctrl);
        }
        Debug.LogWarning(gameObject.name + " LoadFriendly", gameObject);
    }
    public virtual ArmyCtrl GetRandomEnemy()
    {
        int rand = Random.Range(0, this.enemys.Count);
        return this.enemys[rand];
    }
    public virtual ArmyCtrl GetRandomFriendly()
    {
        int rand = Random.Range(0, this.friendly.Count);
        return this.friendly[rand];
    }
}
