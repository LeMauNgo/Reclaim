using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyShooting : SoliderAbstract
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
    protected virtual void LoadFirePoint()
    {
        if (this.firePoint != null) return;
        this.firePoint = this.ctrl.GetComponentInChildren<AttackPoint>();
        Debug.LogWarning(transform.name + "Load FirePoint", gameObject);
    }
    protected virtual void GetTarget()
    {
        this.target = ctrl.Rada.GetTarget();
    }
    protected virtual void LookAtTarget()
    {
        if (this.target == null) return;
        Vector3 direction = target.transform.position - transform.parent.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.parent.rotation = rotation;
        }
    }
    protected virtual bool CanShooting()
    {
        if (this.ctrl.DamageReceiver.IsDead()) return false;
        if (this.target == null)
        {
            this.ctrl.Agent.isStopped = false;
            this.ctrl.Animator.SetBool("IsFire", false);
            return false;
        }
        else
        {
            this.ctrl.Agent.isStopped = true;
            this.ctrl.Animator.SetBool("IsFire", true);
            this.timer += Time.deltaTime;
            return true;
        }
    }
    protected virtual void Shooting()
    {
        if (!this.CanShooting()) return;

        if (this.timer < this.delay) return;
        this.timer = 0;

        this.SpawnProjectile(this.firePoint);
        this.SpawnMuzzle(this.firePoint);
        //this.SpawnSFX(this.firePoint.transform.position);
    }
    protected virtual void SpawnProjectile(AttackPoint firePoint)
    {
        EffectCtrl projectilePrefabs = EffectSpawnerCtrl.Instance.Prefabs.GetByName(EffectCode.Projectile_ElectricBall01_Yellow.ToString());
        EffectCtrl bulletPbs = EffectSpawnerCtrl.Instance.Spawner.Spawn(projectilePrefabs, firePoint.transform.position, firePoint.transform.rotation);
        bulletPbs.gameObject.SetActive(true);
    }
    protected virtual void SpawnMuzzle(AttackPoint firePoint)
    {
        EffectCtrl MuzzlePrefabs = EffectSpawnerCtrl.Instance.Prefabs.GetByName(EffectCode.Muzzle_ElectricBall01_Yellow.ToString());
        EffectCtrl Muzzle = EffectSpawnerCtrl.Instance.Spawner.Spawn(MuzzlePrefabs, firePoint.transform.position, firePoint.transform.rotation);
        Muzzle.gameObject.SetActive(true);
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
