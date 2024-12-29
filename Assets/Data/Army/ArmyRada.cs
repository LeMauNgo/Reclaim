using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public abstract class ArmyRada : MyBehaviour
{
    [SerializeField] protected DamageReceiver nearest;
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected List<DamageReceiver> targets;
    public List<DamageReceiver> Targets => targets;
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
        this.AddTarget(other);
    }
    private void OnTriggerExit(Collider other)
    {
        DamageReceiver target = other.GetComponentInParent<DamageReceiver>();
        if (target == null) return;

        this.RemoveTarget(target);
    }
    protected virtual void AddTarget(Collider other)
    {
        DamageReceiver targetable = other.GetComponent<DamageReceiver>();
        if (targetable == null) return;
        this.targets.Add(targetable);
    }
    protected virtual void RemoveTarget(DamageReceiver target)
    {
        this.targets.Remove(target);
    }
    protected virtual void FindNearest()
    {
        if (this.targets.Count == 0) this.nearest = null;
        float targetDistance;
        float targetMinDistance = Mathf.Infinity;
        foreach (DamageReceiver target in this.targets)
        {
            targetDistance = Vector3.Distance(transform.position, target.transform.position);
            if (targetDistance > targetMinDistance) continue;
            targetMinDistance = targetDistance;
            this.nearest = target;
        }
    }
    public virtual DamageReceiver GetTarget()
    {
        return this.nearest;
    }
    protected virtual void RemoveDeadTarget()
    {
        foreach (DamageReceiver target in this.targets)
        {
            if (target.IsDead())
            {
                if (target == this.nearest) this.nearest = null;
                this.targets.Remove(target);
                return;
            }
        }
    }
}
