using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyArmyRada : ArmyRada
{
    protected override void AddTarget(Collider other)
    {
        GateDamageReceiver gateDamageReceiver = other.GetComponent<GateDamageReceiver>();
        if (gateDamageReceiver != null )
        {
            base.AddTarget(other);
        }

        ArmyCtrl armyCtrl = other.GetComponentInParent<ArmyCtrl>();
        if (armyCtrl == null) return;
        if (armyCtrl.GetTypeArmy() == ArmyType.Friendly) return;
        base.AddTarget(other);
    }
}
