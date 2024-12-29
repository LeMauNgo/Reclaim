using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmyRada : ArmyRada
{
    protected override void AddTarget(Collider other)
    {
        PlayerCtrl playerCtrl = other.GetComponentInParent<PlayerCtrl>();
        if (playerCtrl != null)
        {
            base.AddTarget(other);
        }

        MyGateDamageReceiver myGateDamageReceiver = other.GetComponent<MyGateDamageReceiver>();
        if (myGateDamageReceiver != null)
        {
            base.AddTarget(other);
        }

        ArmyCtrl armyCtrl = other.GetComponentInParent<ArmyCtrl>();
        if(armyCtrl == null) return;
        if (armyCtrl.GetTypeArmy() == ArmyType.Enemy) return;
        base.AddTarget(other);
    }
}
