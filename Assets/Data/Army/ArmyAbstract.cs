using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyAbstract : MyBehaviour
{
    [SerializeField] protected ArmyCtrl ctrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCtrl();
    }
    protected virtual void LoadCtrl()
    {
        if (ctrl != null) return;
        this.ctrl = GetComponentInParent<ArmyCtrl>();
        Debug.Log("LoadCtrl", gameObject);

    }
}
