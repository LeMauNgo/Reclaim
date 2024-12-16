using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.EventSystems;

public class EffectSpawnerCtrl : MySingleton<EffectSpawnerCtrl>
{
    [SerializeField] protected EffectSpawner spawner;
    public EffectSpawner Spawner => spawner;
    [SerializeField] protected EffectPrefabs prefabs;
    public EffectPrefabs Prefabs => prefabs;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawner();
        this.LoadEffectPrefabs();
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<EffectSpawner>();
        Debug.LogWarning(gameObject.name + "LoadSpawner", gameObject);
    }
    protected virtual void LoadEffectPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = GetComponentInChildren<EffectPrefabs>();
        Debug.LogWarning(gameObject.name + "LoadEffectPrefabs", gameObject);
    }
}
