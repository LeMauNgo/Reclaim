using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MySingleton<UIManager>
{
    [SerializeField] protected UICenter uiCenter;
    public UICenter UICenter => uiCenter;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUiCenter();
    }
    protected virtual void LoadUiCenter()
    {
        if (this.uiCenter != null) return;
        this.uiCenter = GetComponentInChildren<UICenter>();
        Debug.LogWarning(gameObject.name + " LoadUiCenter", gameObject);
    }
}
