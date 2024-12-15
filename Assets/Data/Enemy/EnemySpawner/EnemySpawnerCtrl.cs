using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCtrl : MySingleton<EnemySpawnerCtrl>
{
    [SerializeField] protected EnemySpawner spawner;
    public EnemySpawner Spawner => spawner;
    [SerializeField] protected EnemyPrefabs prefabs;
    public EnemyPrefabs Prefabs => prefabs;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawner();
        this.LoadEnemyPrefabs();
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
