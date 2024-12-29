using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICenterAbstract : MyBehaviour
{
    [SerializeField] protected UICenter uICenter;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUiCenter();
    }
    protected virtual void LoadUiCenter()
    {
        if (uICenter != null) return;
        this.uICenter = GetComponentInParent<UICenter>();
        Debug.LogWarning(gameObject.name + " LoadUiCenter", gameObject);
    }
}
