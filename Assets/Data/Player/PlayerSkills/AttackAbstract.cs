using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAbstract : MyBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected EffectSpawner spawner;
    [SerializeField] protected EffectPrefabs prefabs;

    protected void LateUpdate()
    {
        this.Attacking();
    }

    protected abstract void Attacking();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
        this.LoadEffectSpawner();
    }

    protected virtual void LoadEffectSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GameObject.FindAnyObjectByType<EffectSpawner>();
        this.prefabs = GameObject.FindAnyObjectByType<EffectPrefabs>();
        Debug.Log(transform.name + ": LoadEffectSpawner", gameObject);
    }


    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    protected virtual Transform GetAttackPoint()
    {
        return this.playerCtrl.Weapons.GetCurrentWeapon().AttackPoint;
    }
}
