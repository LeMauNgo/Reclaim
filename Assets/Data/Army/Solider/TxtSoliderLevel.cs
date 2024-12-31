using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtSoliderLevel : TxtLevel
{
    [SerializeField] protected SoliderManager soliderManager;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSoliderManager();
    }

    protected virtual void LoadSoliderManager()
    {
        if (this.soliderManager != null) return;
        this.soliderManager = GetComponentInParent<SoliderManager>();
        Debug.Log(transform.name + ": LoadSoliderManager", gameObject);
    }

    protected override string GetLevel()
    {
        return this.soliderManager.CurrentLevel.ToString();
    }
}
