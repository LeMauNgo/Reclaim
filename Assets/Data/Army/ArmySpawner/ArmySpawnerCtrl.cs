using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmySpawnerCtrl : MySingleton<ArmySpawnerCtrl>
{
    [SerializeField] protected ArmySpawner spawner;
    public ArmySpawner Spawner => spawner;
    [SerializeField] protected ArmyPrefabs prefabs;
    public ArmyPrefabs Prefabs => prefabs;
    [SerializeField] protected EnemyWave enemyWave;
    public EnemyWave EnemyWave => enemyWave;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawner();
        this.LoadArmyPrefabs();
        this.LoadEnemyWave();
    }
    protected virtual void LoadEnemyWave()
    {
        if (this.enemyWave != null) return;
        this.enemyWave = GetComponent<EnemyWave>();
        Debug.LogWarning(gameObject.name + " LoadEnemyWave", gameObject);
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<ArmySpawner>();
        Debug.LogWarning(gameObject.name + "LoadSpawner", gameObject);
    }
    protected virtual void LoadArmyPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = GetComponentInChildren<ArmyPrefabs>();
        Debug.LogWarning(gameObject.name + "LoadArmyPrefabs", gameObject);
    }
}
