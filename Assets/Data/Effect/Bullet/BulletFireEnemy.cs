using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFireEnemy : BulletDamageSender
{
    protected override bool CanSendDamage(Collider collider)
    {
        GateDamageReceiver gateDamageReceiver = collider.GetComponent<GateDamageReceiver>();
        if (gateDamageReceiver != null)
        {
            return true;
        }

        ArmyCtrl armyCtrl = collider.GetComponentInParent<ArmyCtrl>();
        if (armyCtrl == null) return false;
        ArmyType armyType = armyCtrl.GetTypeArmy();
        if (armyType == ArmyType.Enemy) return true; return false;
    }
    protected override void SpawnHit(Vector3 posittion)
    {
        base.SpawnHit(posittion);
        EffectCtrl HitPrefabs = EffectSpawnerCtrl.Instance.Prefabs.GetByName(EffectCode.Hit_ElectricBall01_Green.ToString());
        EffectCtrl hit = EffectSpawnerCtrl.Instance.Spawner.Spawn(HitPrefabs, posittion);
        hit.gameObject.SetActive(true);
    }
}
