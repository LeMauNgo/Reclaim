using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SholiderMove : SoliderAbstract
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
        if (this.ctrl.GetTypeArmy() == ArmyType.Enemy)
        {
            this.pathCtrl = GameObject.Find("PathMoving_0").GetComponent<PathCtrl>();
        }
        else
        {
            this.pathCtrl = GameObject.Find("PathMoving_1").GetComponent<PathCtrl>();
        }
        
        Debug.Log("LoadPathCtrl", gameObject);
    }
    private void FixedUpdate()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        this.MovingStatus();
        if(isFinish || !canMove || this.IsDeath())
        {
            //transform.parent.position = new Vector3(0, 0, 0);
            this.ctrl.Agent.isStopped = true;
            return;
        }
        this.currentPoint = this.pathCtrl.GetPoint(currnetPointIndex);
        this.GetNextPoint();
        this.ctrl.Agent.SetDestination(currentPoint);
    }
    protected virtual bool IsDeath()
    {
        return this.ctrl.DamageReceiver.IsDead();
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
        this.canMove = !this.ctrl.Agent.isStopped;
        this.ctrl.Animator.SetBool("IsMoving", canMove);
    }
}
