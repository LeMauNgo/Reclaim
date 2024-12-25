using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MyBehaviour
{
    [SerializeField] protected ArmySpawnerCtrl ctrl;
    [SerializeField] protected float spawnSpeed = 1f;
    [SerializeField] protected int maxSpawn = 15;
    [SerializeField] protected List<ArmyCtrl> spawnedEnemies = new();

    private void Start()
    {
        Invoke(nameof(this.Spawning), this.spawnSpeed);
    }

    protected virtual void FixedUpdate()
    {
        this.RemoveDeadOne();
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

        if (this.spawnedEnemies.Count >= this.maxSpawn) return;

        ArmyCtrl prefab = this.ctrl.Prefabs.GetRandomEnemy();
        ArmyCtrl newEnemy = this.ctrl.Spawner.Spawn(prefab, transform.position);
        newEnemy.gameObject.SetActive(true);
        this.spawnedEnemies.Add(newEnemy);
    }

    protected virtual void RemoveDeadOne()
    {
        foreach (ArmyCtrl enemyCtrl in this.spawnedEnemies)
        {
            if (enemyCtrl.DamageReceiver.IsDead())
            {
                this.spawnedEnemies.Remove(enemyCtrl);
                return;
            }
        }
    }
    public virtual void KillAllEnemy()
    {
        foreach (ArmyCtrl enemyCtrl in spawnedEnemies)
        {
            enemyCtrl.DamageReceiver.Receive(500);
        }
    }
}
