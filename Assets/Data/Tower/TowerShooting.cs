using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected MyTeam target;
    [SerializeField] protected float timer;
    [SerializeField] protected int delay = 1;
    [SerializeField] protected List<AttackPoint> firePoints;
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
        if (this.firePoints.Count > 0) return;
        AttackPoint[] firePoints = this.towerCtrl.GetComponentsInChildren<AttackPoint>();
        this.firePoints = new List<AttackPoint>(firePoints);
        Debug.LogWarning(transform.name + "Load FirePoint", gameObject);
    }
    protected virtual AttackPoint GetFirePoint()
    {
        int pointIndex = Random.Range(0, firePoints.Count);
        return firePoints[pointIndex];
    }
    protected virtual void GetTarget()
    {
        this.target = towerCtrl.Rada.GetTarget();
    }
    protected virtual void LookAtTarget()
    {
        if (this.target == null) return;
        this.towerCtrl.Rotator.LookAt(this.target.transform.position);
    }
    protected virtual void Shooting()
    {
        if (this.target == null) return;
        this.timer += Time.deltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;

        AttackPoint firePoint = GetFirePoint();
        this.SpawnProjectile(firePoint);
        this.SpawnMuzzle(firePoint);
        //this.SpawnSFX(firePoint.transform.position);
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
        if (!this.target.DamageReceiver.IsDead()) return false;
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
