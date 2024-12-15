using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyCtrl : PoolObj
{
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    [SerializeField] protected EnemyDamageReceiver damageReceiver;
    public EnemyDamageReceiver EnemyDamageReceiver => damageReceiver;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAgent();
        this.LoadAnimator();
        this.LoadEnemyDamageReceiver();
    }
    void LoadAgent()
    {
        if (agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        Debug.Log("LoadAgent", gameObject);
    }
    void LoadAnimator()
    {
        if (animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
        Debug.Log("LoadAnimator", gameObject);
    }
    protected virtual void LoadEnemyDamageReceiver()
    {
        if (damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<EnemyDamageReceiver>();
        Debug.Log("LoadAnimator", gameObject);
    }
}
