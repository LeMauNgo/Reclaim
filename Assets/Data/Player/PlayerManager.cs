using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MySingleton<PlayerManager>
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInChildren<PlayerCtrl>();
        Debug.LogWarning(gameObject.name + " LoadPlayerCtrl", gameObject);
    }
}
