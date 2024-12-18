using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class SoliderRada : MyBehaviour
{
    [SerializeField] protected EnemyCtrl nearest;
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected List<EnemyCtrl> enemies;
    public List<EnemyCtrl> Enemies => enemies;
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
        this.RemoveDeadEnemy();
        this.FindNearest();
    }
    private void OnTriggerEnter(Collider other)
    {
        Targetable targetable = other.GetComponent<Targetable>();
        if (targetable == null) return;

        this.AddEnemy(targetable);
        //Debug.Log(other.name + " " , other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        EnemyCtrl enemy = other.GetComponentInParent<EnemyCtrl>();
        if (enemy == null) return;

        this.RemoveEnemy(enemy);
    }
    protected virtual void AddEnemy(Targetable targetable)
    {
        EnemyCtrl enemy = targetable.GetComponentInParent<EnemyCtrl>();
        if (enemy == null) return;
        this.enemies.Add(enemy);
    }
    protected virtual void RemoveEnemy(EnemyCtrl enemy)
    {
        this.enemies.Remove(enemy);
    }
    protected virtual void FindNearest()
    {
        if (this.enemies.Count == 0) this.nearest = null;
        float enemyDistance;
        float enemyMinDistance = Mathf.Infinity;
        foreach (EnemyCtrl enemy in this.enemies)
        {
            enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance > enemyMinDistance) continue;
            enemyMinDistance = enemyDistance;
            this.nearest = enemy;
        }
    }
    private void OnEnable()
    {
        this.RemoveTarget();
    }
    public virtual void RemoveTarget()
    {
        this.enemies.Clear();
        this.nearest = null;
    }
    public virtual EnemyCtrl GetEnemy()
    {
        return this.nearest;
    }
    protected virtual void RemoveDeadEnemy()
    {
        foreach (EnemyCtrl enemyCtrl in this.enemies)
        {
            if (enemyCtrl.EnemyDamageReceiver.IsDead())
            {
                if (enemyCtrl == this.nearest) this.nearest = null;
                this.enemies.Remove(enemyCtrl);
                return;
            }
        }
    }
}
