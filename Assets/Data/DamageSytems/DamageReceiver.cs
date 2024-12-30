using UnityEngine;
//using UnityEngine.EventSystems;
[RequireComponent(typeof(Collider))]
public abstract class DamageReceiver : MyBehaviour
{
    [SerializeField] protected int currentHP = 10;
    [SerializeField] protected int maxHP = 10;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected bool isImmotal = false;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
    }
    private void OnEnable()
    {
        this.Rebone();
    }
    public virtual void Healing(int Blood)
    {
        if(IsDead()) return;
        this.currentHP += Blood;
        if (this.currentHP < maxHP) return;
        this.currentHP = maxHP;
    }
    protected virtual void Rebone()
    {
        this.currentHP = this.maxHP;
    }
    public virtual void Receive(int damage)
    {
        if (!this.isImmotal) this.currentHP -= damage;
        if (this.currentHP < 0) this.currentHP = 0;

        if (this.IsDead()) this.OnDead();
        else this.OnHurt();
    }
    protected abstract void LoadCollider();
    public virtual bool IsDead()
    {
        return this.isDead = this.currentHP <= 0;
    }
    public virtual float HPRatio()
    {
        return (float)this.currentHP / (float)this.maxHP;
    }
    protected abstract void OnDead();

    protected abstract void OnHurt();
}