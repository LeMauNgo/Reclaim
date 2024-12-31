using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnToggleSetting : BaseBtn
{
    protected override void OnClick()
    {
        UISetting uISetting = (UISetting)UIManager.Instance.UICenter.GetUiCenterByName("UiSetting");
        uISetting.Toggle();
    }
}
