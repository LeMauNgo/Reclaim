using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UICenter : MyBehaviour
{
    [SerializeField] protected List<UICenterCtrl> ctrls;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUiCenterCtrl();
    }
    private void OnEnable()
    {
        this.ShowUiCenter("Bull'sEye");
    }
    protected virtual void LoadUiCenterCtrl()
    {
        if (this.ctrls.Count > 0) return;
        UICenterCtrl[] centerCtrls = GetComponentsInChildren<UICenterCtrl>();
        this.ctrls = centerCtrls.ToList();
        Debug.LogWarning(gameObject.name + " LoadUiCenterCtrl", gameObject);
    }
    public virtual UICenterCtrl GetUiCenterByName(string name)
    {
        foreach (UICenterCtrl ctrl in this.ctrls)
        {
            if (ctrl.name != name) continue;
            return ctrl;
        }
        return null;
    }
    public virtual void ShowUiCenter(string ctrlName)
    {
        foreach(UICenterCtrl uiCtrl in ctrls)
        {
            if (uiCtrl.transform.name != ctrlName)
            {
                if(uiCtrl.ShowHide == null)
                {
                    Debug.LogWarning(uiCtrl.transform.name);
                    continue;
                }
                uiCtrl.ShowHide.gameObject.SetActive(false);
            }
            else
            {
                uiCtrl.ShowHide.gameObject.SetActive(true);
            }
        }
    }
    public virtual void HideUiCenter()
    {
        this.ShowUiCenter("Bull'sEye");
    }
}
