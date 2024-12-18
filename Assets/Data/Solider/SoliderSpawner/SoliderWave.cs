using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderWave : MyBehaviour
{
    [SerializeField] protected SoliderSpawnerCtrl ctrl;
    [SerializeField] protected float spawnSpeed = 1f;
    [SerializeField] protected int maxSpawn = 50;
    [SerializeField] protected List<SoliderCtrl> spawnedSolider = new();

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
        this.LoadSoliderSpawnerCtrl();
    }

    protected virtual void LoadSoliderSpawnerCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponent<SoliderSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadSoliderSpawnerCtrl", gameObject);
    }

    protected virtual void Spawning()
    {
        Invoke(nameof(this.Spawning), this.spawnSpeed);

        if (this.spawnedSolider.Count >= this.maxSpawn) return;

        SoliderCtrl prefab = this.ctrl.Prefabs.GetByName("Swat");
        SoliderCtrl newEnemy = this.ctrl.Spawner.Spawn(prefab, transform.position);
        newEnemy.gameObject.SetActive(true);
        this.spawnedSolider.Add(newEnemy);
    }

    protected virtual void RemoveDeadOne()
    {
        foreach (SoliderCtrl soliderCtrl in this.spawnedSolider)
        {
            if (soliderCtrl.SoliderDamageReceiver.IsDead())
            {
                this.spawnedSolider.Remove(soliderCtrl);
                return;
            }
        }
    }
}
