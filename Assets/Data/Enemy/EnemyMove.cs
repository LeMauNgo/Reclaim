using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : EnemyAbstract
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
    private void Start()
    {
        
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPathCtrl();
    }
    void LoadPathCtrl()
    {
        if (pathCtrl != null) return;
        this.pathCtrl = GameObject.Find("PathMoving_0").GetComponent<PathCtrl>();
        Debug.Log("LoadPathCtrl", gameObject);
    }
    private void Update()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        this.MovingStatus();
        if(isFinish || !canMove || this.IsDeath())
        {
            this.enemyCtrl.Agent.isStopped = true;
            return;
        }
        this.currentPoint = this.pathCtrl.GetPoint(currnetPointIndex);
        this.GetNextPoint();
        this.enemyCtrl.Agent.SetDestination(currentPoint);
    }
    protected virtual bool IsDeath()
    {
        return this.enemyCtrl.EnemyDamageReceiver.IsDead();
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
        this.canMove = !this.enemyCtrl.Agent.isStopped;
        this.enemyCtrl.Animator.SetBool("IsMoving", canMove);
    }
}
