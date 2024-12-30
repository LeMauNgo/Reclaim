using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFireMyTeam : BulletDamageSender
{
    protected override bool CanSendDamage(Collider collider)
    {
        PlayerCtrl playerCtrl = collider.GetComponentInParent<PlayerCtrl>();
        if (playerCtrl != null ) return true;

        MyGateDamageReceiver myGateDamageReceiver = collider.GetComponent<MyGateDamageReceiver>();
        if (myGateDamageReceiver != null) return true;

        ArmyCtrl armyCtrl = collider.GetComponentInParent<ArmyCtrl>();
        if (armyCtrl == null) return false;
        ArmyType armyType = armyCtrl.GetTypeArmy();
        if (armyType == ArmyType.Ally) return true;
        return false;

    }
    protected override void SpawnHit(Vector3 posittion)
    {
        base.SpawnHit(posittion);
        EffectCtrl HitPrefabs = EffectSpawnerCtrl.Instance.Prefabs.GetByName(EffectCode.Hit_ElectricBall01_Yellow.ToString());
        EffectCtrl hit = EffectSpawnerCtrl.Instance.Spawner.Spawn(HitPrefabs, posittion);
        hit.gameObject.SetActive(true);
    }
}
