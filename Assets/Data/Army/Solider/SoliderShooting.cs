using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoliderShooting : ArmyShooting
{
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
    protected override void LoadFirePoint()
    {
        if (this.firePoint != null) return;
        this.firePoint = this.ctrl.GetComponentInChildren<AttackPoint>();
        Debug.LogWarning(transform.name + "Load FirePoint", gameObject);
    }
    protected override void LookAtTarget()
    {
        if (this.target == null) return;
        Vector3 direction = target.transform.position - transform.parent.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.parent.rotation = rotation;
        }
    }
    protected override bool CanShooting()
    {
        SoliderCtrl ctrl = (SoliderCtrl)this.ctrl;
        if (this.ctrl.DamageReceiver.IsDead()) return false;
        if (this.target == null)
        {
            ctrl.Agent.isStopped = false;
            ctrl.Animator.SetBool("IsFire", false);
            return false;
        }
        else
        {
            ctrl.Agent.isStopped = true;
            ctrl.Animator.SetBool("IsFire", true);
            this.timer += Time.deltaTime;
            return true;
        }
    }
}
