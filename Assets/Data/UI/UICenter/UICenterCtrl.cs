using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UICenterCtrl : UICenterAbstract
{
    [SerializeField] protected Transform showHide;
    public Transform ShowHide => showHide;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShowHide();
    }
    protected virtual void LoadShowHide()
    {
        if (this.showHide != null) return;
        this.showHide = transform.Find("ShowHide");
        Debug.Log(transform.name + ": LoadShowHide", gameObject);
    }
}
