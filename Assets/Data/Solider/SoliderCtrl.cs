using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class SoliderCtrl : PoolObj
{
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    [SerializeField] protected SoliderDamageReceiver damageReceiver;
    public SoliderDamageReceiver SoliderDamageReceiver => damageReceiver;
    [SerializeField] protected SoliderRada soliderRada;
    public SoliderRada SoliderRada => soliderRada;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAgent();
        this.LoadAnimator();
        this.LoadSoliderDamageReceiver();
        this.LoadSoliderRada();
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
    protected virtual void LoadSoliderDamageReceiver()
    {
        if (damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<SoliderDamageReceiver>();
        Debug.Log("LoadSoliderDamageReceiver", gameObject);
    }
    protected virtual void LoadSoliderRada()
    {
        if (soliderRada != null) return;
        this.soliderRada = GetComponentInChildren<SoliderRada>();
        Debug.Log("LoadSoliderRada", gameObject);
    }
}
