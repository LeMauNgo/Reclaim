using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MyBehaviour
{
    [SerializeField] protected ArmySpawnerCtrl ctrl;
    [SerializeField] protected float spawnSpeed = 1f;
    [SerializeField] protected int maxSpawn = 15;

    private void Start()
    {
        Invoke(nameof(this.Spawning), this.spawnSpeed);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnerCtrl();
    }

    protected virtual void LoadSpawnerCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponent<ArmySpawnerCtrl>();
        Debug.Log(transform.name + ": LoadEnemySpawnerCtrl", gameObject);
    }

    protected virtual void Spawning()
    {
        if (!GameManager.Instance.IsPlaying()) return;
        Invoke(nameof(this.Spawning), this.spawnSpeed);

        if (this.ctrl.ArmyManager.EnemySoliders.Count >= this.maxSpawn) return;

        ArmyCtrl prefab = this.ctrl.Prefabs.GetRandomEnemy();
        ArmyCtrl newEnemy = this.ctrl.Spawner.Spawn(prefab);
        newEnemy.gameObject.SetActive(true);
        this.ctrl.ArmyManager.AddEnemy((SoliderCtrl) newEnemy);
    }
}
