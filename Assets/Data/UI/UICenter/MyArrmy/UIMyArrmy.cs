using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMyArrmy : UICenterCtrl
{
    [SerializeField] protected bool isShow;
    public bool IsShow => isShow;
    public virtual void Show()
    {
        this.isShow = true;
        this.uICenter.ShowUiCenter(transform.name);
    }

    public virtual void Hide()
    {
        this.uICenter.HideUiCenter();
        this.isShow = false;
    }

    public virtual void Toggle()
    {
        if (this.isShow) this.Hide();
        else this.Show();
    }
}
