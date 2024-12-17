using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderMove : SoliderAbstract
{
    [SerializeField] protected PathCtrl pathCtrl;
    [SerializeField] protected int currnetPointIndex;
    [SerializeField] protected Vector3 currentPoint;
    [SerializeField] protected float pointDistance = Mathf.Infinity;
    [SerializeField] protected float pointDistanceMin = 1;
    [SerializeField] protected bool isFinish;
    [SerializeField] protected bool canMove;
    private void OnEnable()
    {
        this.currnetPointIndex = 0;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPathCtrl();
    }
    void LoadPathCtrl()
    {
        if (pathCtrl != null) return;
        this.pathCtrl = GameObject.Find("PathMoving_1").GetComponent<PathCtrl>();
        Debug.Log("LoadPathCtrl", gameObject);
    }
    private void Update()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        this.MovingStatus();
        if (isFinish || !canMove || this.IsDeath())
        {
            this.soliderCtrl.Agent.isStopped = true;
            return;
        }
        this.currentPoint = this.pathCtrl.GetPoint(currnetPointIndex);
        this.GetNextPoint();
        this.soliderCtrl.Agent.SetDestination(currentPoint);
    }
    protected virtual bool IsDeath()
    {
        return this.soliderCtrl.SoliderDamageReceiver.IsDead();
    }
    protected virtual void GetNextPoint()
    {
        if (isFinish) return;
        this.pointDistance = Vector3.Distance(transform.parent.position, currentPoint);
        if (this.pointDistance < pointDistanceMin) currnetPointIndex++;
        if (this.currnetPointIndex >= this.pathCtrl.Points.Count) this.isFinish = true;
    }
    protected virtual void MovingStatus()
    {
        this.canMove = !this.soliderCtrl.Agent.isStopped;
        this.soliderCtrl.Animator.SetBool("IsMoving", canMove);
    }
}
