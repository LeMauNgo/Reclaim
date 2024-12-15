using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WeaponsCtrl : MyBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform attackPoint;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadAttackPoint();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.transform.localPosition = new Vector3(-0.0370000005f, 0.825999975f, 0.345999986f);
        this.transform.localRotation = Quaternion.Euler(new Vector3(1.03103042f, 179.847427f, 274.619232f));
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadAttackPoint()
    {
        if(this.attackPoint != null) return;
        this.attackPoint = transform.Find("AttackPoint");
        Debug.LogWarning(transform.name + ": LoadAttackPoint", gameObject);
    }
}
