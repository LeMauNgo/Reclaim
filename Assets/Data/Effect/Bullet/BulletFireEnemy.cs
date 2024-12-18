using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFireEnemy : BulletDamageSender
{
    protected override bool CanSendDamage(Collider collider)
    {
        if(collider.GetComponentInParent<EnemyCtrl>()) return true; return false;
    }
    protected override void SpawnHit(Vector3 posittion)
    {
        base.SpawnHit(posittion);
        EffectCtrl HitPrefabs = EffectSpawnerCtrl.Instance.Prefabs.GetByName(EffectCode.Hit_ElectricBall01_Yellow.ToString());
        EffectCtrl hit = EffectSpawnerCtrl.Instance.Spawner.Spawn(HitPrefabs, posittion);
        hit.gameObject.SetActive(true);
    }
}
