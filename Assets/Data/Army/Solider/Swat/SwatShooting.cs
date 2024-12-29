using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatShooting : SoliderShooting
{
    protected override void SpawnProjectile(AttackPoint firePoint)
    {
        EffectCtrl projectilePrefabs = EffectSpawnerCtrl.Instance.Prefabs.GetByName(EffectCode.Projectile_ElectricBall01_Green.ToString());
        EffectCtrl bulletPbs = EffectSpawnerCtrl.Instance.Spawner.Spawn(projectilePrefabs, firePoint.transform.position, firePoint.transform.rotation);
        bulletPbs.gameObject.SetActive(true);
    }
    protected override void SpawnMuzzle(AttackPoint firePoint)
    {
        EffectCtrl MuzzlePrefabs = EffectSpawnerCtrl.Instance.Prefabs.GetByName(EffectCode.Muzzle_ElectricBall01_Green.ToString());
        EffectCtrl Muzzle = EffectSpawnerCtrl.Instance.Spawner.Spawn(MuzzlePrefabs, firePoint.transform.position, firePoint.transform.rotation);
        Muzzle.gameObject.SetActive(true);
    }
}
