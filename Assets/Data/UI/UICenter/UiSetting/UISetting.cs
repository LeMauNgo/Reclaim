using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetting : UICenterCtrl
{
    [SerializeField] protected bool isShow = true;
    protected bool IsShow => isShow;


    protected virtual void LateUpdate()
    {
        this.HotkeyToogleSetting();
    }

    private void Start()
    {
        this.Hide();
    }

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

    protected virtual void HotkeyToogleSetting()
    {
        if (InputHotkeys.Instance.IsToogleSetting) this.Toggle();
    }
}

