using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyAbstract : MyBehaviour
{
    [SerializeField] protected ArmyCtrl armyCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCtrl();
    }
    protected virtual void LoadCtrl()
    {
        if (armyCtrl != null) return;
        this.armyCtrl = GetComponentInParent<ArmyCtrl>();
        Debug.Log("LoadCtrl", gameObject);

    }
}
