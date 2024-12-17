using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFireEnemy : BulletDamageSender
{
    protected override bool CanSendDamage(Collider collider)
    {
        if(collider.GetComponentInParent<EnemyCtrl>()) return true; return false;
    }
}
