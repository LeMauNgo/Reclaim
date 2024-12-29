using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmyShooting : ArmyAbstract
{
    [SerializeField] protected DamageReceiver target;
    [SerializeField] protected float timer;
    [SerializeField] protected int delay = 1;
    [SerializeField] protected AttackPoint firePoint;
    [SerializeField] protected int killCount;
    public int KillCount => killCount;
    [SerializeField] protected int totalKill;
    private void Update()
    {
        this.GetTarget();
        this.LookAtTarget();
        this.Shooting();
        this.IsTargetDead();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadFirePoint();
    }
    protected abstract void SpawnProjectile(AttackPoint firePoint);
    protected abstract void SpawnMuzzle(AttackPoint firePoint);
    protected abstract bool CanShooting();
    protected abstract void LoadFirePoint();
    protected abstract void LookAtTarget();

    protected virtual void GetTarget()
    {
        this.target = ctrl.Rada.GetTarget();
    }

    protected virtual void Shooting()
    {
        if (!this.CanShooting()) return;

        if (this.timer < this.delay) return;
        this.timer = 0;

        this.SpawnProjectile(this.firePoint);
        this.SpawnMuzzle(this.firePoint);
    }

    protected virtual void SpawnSFX(Vector3 position)
    {
        SoundManager.Instance.CreateSfx(SoundName.LaserOneShoot, position);
    }
    protected virtual bool IsTargetDead()
    {
        if (this.target == null) return true;
        if (!this.target.IsDead()) return false;
        this.killCount++;
        this.totalKill++;
        this.target = null;
        return true;
    }

    public virtual bool DeductKillCount(int count)
    {
        if (this.killCount < count) return false;
        this.killCount -= count;
        return true;
    }
}
