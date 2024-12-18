using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyRada : MyBehaviour
{
    [SerializeField] protected MyTeam nearest;
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected List<MyTeam> targets;
    public List<MyTeam> Targets => targets;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadRigidbody();
    }
    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.radius = 20;
        this._collider.isTrigger = true;
        Debug.LogWarning(gameObject.name + "Load Collider", gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        Debug.LogWarning(gameObject.name + "Load Rigidbody", gameObject);
    }
    private void FixedUpdate()
    {
        this.RemoveDeadTarget();
        this.FindNearest();
    }
    private void OnEnable()
    {
        this.RemoveTarget();
    }
    public virtual void RemoveTarget()
    {
        this.targets.Clear();
        this.nearest = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        MyTeam targetable = other.GetComponent<MyTeam>();
        if (targetable == null) return;

        this.AddTarget(targetable);
        //Debug.Log(other.name + " " , other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        MyTeam target = other.GetComponentInParent<MyTeam>();
        if (target == null) return;

        this.RemoveTarget(target);
    }
    protected virtual void AddTarget(MyTeam targetable)
    {
        MyTeam target = targetable.GetComponentInParent<MyTeam>();
        if (target == null) return;
        this.targets.Add(target);
    }
    protected virtual void RemoveTarget(MyTeam target)
    {
        this.targets.Remove(target);
    }
    protected virtual void FindNearest()
    {
        if (this.targets.Count == 0) this.nearest = null;
        float targetDistance;
        float targetMinDistance = Mathf.Infinity;
        foreach (MyTeam target in this.targets)
        {
            targetDistance = Vector3.Distance(transform.position, target.transform.position);
            if (targetDistance > targetMinDistance) continue;
            targetMinDistance = targetDistance;
            this.nearest = target;
        }
    }
    public virtual MyTeam GetTarget()
    {
        return this.nearest;
    }
    protected virtual void RemoveDeadTarget()
    {
        foreach (MyTeam target in this.targets)
        {
            if (target.DamageReceiver.IsDead())
            {
                if (target == this.nearest) this.nearest = null;
                this.targets.Remove(target);
                return;
            }
        }
    }
}
