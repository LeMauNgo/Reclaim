using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnToggleArmy : BaseBtn
{
    protected override void Onclick()
    {
        UIMyArrmy uIMyArrmy = (UIMyArrmy)UIManager.Instance.UICenter.GetUiCenterByName("MyArrmy");
        uIMyArrmy.Toggle();
    }
}
