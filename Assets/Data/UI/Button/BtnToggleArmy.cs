using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnToggleArmy : BaseBtn
{
    protected override void OnClick()
    {
        UIMyArrmy uIMyArrmy = (UIMyArrmy)UIManager.Instance.UICenter.GetUiCenterByName("MyArrmy");
        uIMyArrmy.Toggle();
    }
}
