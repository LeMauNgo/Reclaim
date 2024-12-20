using UnityEngine;
//using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public abstract class DamageSender : MyBehaviour
{
    [SerializeField] protected int damage = 1;
    [SerializeField] protected Rigidbody rigid;
    [SerializeField] protected Collider _collider;

    protected virtual void OnTriggerEnter(Collider collider)
    {
        this.SendDamage(collider);
    }

    protected virtual DamageReceiver SendDamage(Collider collider)
    {
        //Debug.LogError(transform.parent.name + " / " + collider.transform.parent.name);
        DamageReceiver damageReceiver = collider.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return null;

        this.SpawnHit(damageReceiver.transform.position);
        damageReceiver.Receive(this.damage);
        return damageReceiver;
    }
    protected virtual void SpawnHit(Vector3 posittion)
    {
        //EffectCtrl HitPrefabs = EffectSpawnerCtrl.Instance.Prefabs.GetByName(EffectCode.Hit_ElectricBall01_Green.ToString());
        //EffectCtrl hit = EffectSpawnerCtrl.Instance.Spawner.Spawn(HitPrefabs, posittion);
        //hit.gameObject.SetActive(true);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
        this.LoadTriggerCollider();
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rigid != null) return;
        this.rigid = GetComponent<Rigidbody>();
        this.rigid.useGravity = false;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void LoadTriggerCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<Collider>();
        this._collider.isTrigger = true;
        Debug.Log(transform.name + ": LoadTriggerCollider", gameObject);
    }

}