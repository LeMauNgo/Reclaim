using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCtrl : MySingleton<EnemySpawnerCtrl>
{
    [SerializeField] protected EnemySpawner spawner;
    public EnemySpawner Spawner => spawner;
    [SerializeField] protected EnemyPrefabs prefabs;
    public EnemyPrefabs Prefabs => prefabs;
    [SerializeField] protected EnemyWave enemyWave;
    public EnemyWave EnemyWave => enemyWave;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawner();
        this.LoadEnemyPrefabs();
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
        this.spawner = GetComponent<EnemySpawner>();
        Debug.LogWarning(gameObject.name + "LoadSpawner", gameObject);
    }
    protected virtual void LoadEnemyPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = GetComponentInChildren<EnemyPrefabs>();
        Debug.LogWarning(gameObject.name + "LoadEnemyPrefabs", gameObject);
    }
}
