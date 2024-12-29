using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerShooting : ArmyShooting
{
    [SerializeField] protected List<AttackPoint> firePoints;
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
        if (this.firePoints.Count > 0) return;
        AttackPoint[] firePoints = this.ctrl.GetComponentsInChildren<AttackPoint>();
        this.firePoints = new List<AttackPoint>(firePoints);
        Debug.LogWarning(transform.name + "Load FirePoint", gameObject);
    }
    protected virtual AttackPoint GetFirePoint()
    {
        int pointIndex = Random.Range(0, firePoints.Count);
        this.firePoint = firePoints[pointIndex];
        return this.firePoint;
    }
    protected override void LookAtTarget()
    {
        if (this.target == null) return;
        TowerCtrl ctrl = (TowerCtrl)this.ctrl;
        ctrl.Rotator.LookAt(this.target.transform.position);
    }

    protected override bool CanShooting()
    {
        if (this.target == null) return false;
        this.timer += Time.deltaTime;
        this.GetFirePoint();
        return true;
    }
}
