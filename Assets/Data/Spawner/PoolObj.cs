using UnityEngine;
//using UnityEngine.EventSystems;

public abstract class PoolObj : MyBehaviour
{
    [SerializeField] protected DespawnBase despawn;
    public DespawnBase Despawn => despawn;

    public abstract string GetName();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDespawn();
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<DespawnBase>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }
}