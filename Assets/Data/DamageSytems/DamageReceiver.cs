using UnityEngine;
//using UnityEngine.EventSystems;

public abstract class DamageReceiver : MyBehaviour
{
    [SerializeField] protected int currentHP = 10;
    [SerializeField] protected int maxHP = 10;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected bool isImmotal = false;

    private void OnEnable()
    {
        this.Rebone();
    }
    protected virtual void Rebone()
    {
        this.currentHP = this.maxHP;
    }
    public virtual void Receive(int damage, DamageSender damageSender)
    {
        if (!this.isImmotal) this.currentHP -= damage;
        if (this.currentHP < 0) this.currentHP = 0;

        if (this.IsDead()) this.OnDead();
        else this.OnHurt();
    }

    public virtual bool IsDead()
    {
        return this.isDead = this.currentHP <= 0;
    }

    protected abstract void OnDead();

    protected abstract void OnHurt();
}