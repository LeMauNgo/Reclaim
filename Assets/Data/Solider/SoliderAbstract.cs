using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderAbstract : MyBehaviour
{
    [SerializeField] protected SoliderCtrl soliderCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSoliderCtrl();
    }
    protected virtual void LoadSoliderCtrl()
    {
        if (soliderCtrl != null) return;
        this.soliderCtrl = GetComponentInParent<SoliderCtrl>();
        Debug.Log("LoadSoliderCtrl", gameObject);
    }
}
