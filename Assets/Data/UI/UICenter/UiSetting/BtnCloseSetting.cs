using UnityEngine;

public class BtnCloseSetting : BaseBtn
{
    [SerializeField] protected UISetting uISetting;
    public UISetting UISetting => uISetting;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUiSetting();
    }
    protected virtual void LoadUiSetting()
    {
        if (this.uISetting != null) return;
        this.uISetting = GetComponentInParent<UISetting>();
        Debug.LogWarning(gameObject.name + " LoadUiSetting", gameObject);
    }
    protected override void OnClick()
    {
        this.UISetting.Hide();
    }
}
