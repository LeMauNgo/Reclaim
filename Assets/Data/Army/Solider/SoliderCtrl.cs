using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class SoliderCtrl : ArmyCtrl
{
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAgent();
        this.LoadAnimator();
    }
    protected virtual void LoadAgent()
    {
        if (agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        Debug.Log("LoadAgent", gameObject);
    }
    protected virtual void LoadAnimator()
    {
        if (animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
        Debug.Log("LoadAnimator", gameObject);
    }
}
