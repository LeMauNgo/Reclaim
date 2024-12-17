using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderSpawnerCtrl : MySingleton<SoliderSpawnerCtrl>
{
    [SerializeField] protected SoliderSpawner spawner;
    public SoliderSpawner Spawner => spawner;
    [SerializeField] protected SoliderPrefabs prefabs;
    public SoliderPrefabs Prefabs => prefabs;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawner();
        this.LoadSoliderPrefabs();
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<SoliderSpawner>();
        Debug.LogWarning(gameObject.name + "LoadSpawner", gameObject);
    }
    protected virtual void LoadSoliderPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = GetComponentInChildren<SoliderPrefabs>();
        Debug.LogWarning(gameObject.name + "LoadSoliderPrefabs", gameObject);
    }
}
