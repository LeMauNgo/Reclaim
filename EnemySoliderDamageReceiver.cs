using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider))]
public class SoliderDamageReceiver : ArmyDamageReceiver
{
    protected override void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<CapsuleCollider>();
        CapsuleCollider capsuleCollider = (CapsuleCollider)this._collider;
        capsuleCollider.radius = 0.3f;
        capsuleCollider.height = 2;
        capsuleCollider.center = new Vector3(0, 1, 0);
        capsuleCollider.isTrigger = true;
        Debug.LogWarning(gameObject.name + "LoadCollider", gameObject);
    }
    protected override void OnDead()
    {
        EnemySoliderCtrl ctrl = (EnemySoliderCtrl)this.ctrl;
        ctrl.Animator.SetBool("IsDeath", this.isDead);
        base.OnDead();
    }
}
