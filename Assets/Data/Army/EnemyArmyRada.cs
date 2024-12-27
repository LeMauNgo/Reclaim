using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmyRada : ArmyRada
{
    protected override void AddTarget(Collider other)
    {
        ArmyCtrl armyCtrl = other.GetComponentInParent<ArmyCtrl>();
        if(armyCtrl == null) return;
        if (armyCtrl.GetTypeArmy() == ArmyType.Enemy) return;
        base.AddTarget(other);
    }
}
