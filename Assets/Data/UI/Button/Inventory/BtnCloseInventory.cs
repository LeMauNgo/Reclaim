using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseInventory : BaseBtn
{
    [SerializeField] protected UiInventory uiInventory;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUiInventory();
    }
    protected virtual void LoadUiInventory()
    {
        if (this.uiInventory != null) return;
        this.uiInventory = GetComponentInParent<UiInventory>();
        Debug.Log(gameObject.name + "LoadUiInventory", gameObject);
    }
    protected override void Onclick()
    {
        this.uiInventory.Hide();
    }
}
