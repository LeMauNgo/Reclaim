using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoliderAbstract : MyBehaviour
{
    [SerializeField] protected SoliderCtrl ctrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCtrl();
    }
    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponentInParent<SoliderCtrl>();
        Debug.Log("LoadCtrl", gameObject);
    }
}
