using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnToggleInventory : BaseBtn
{
    protected override void Onclick()
    {
        UiInventory uiInventory = (UiInventory)UIManager.Instance.UICenter.GetUiCenterByName("UiInventory");
        uiInventory.Toggle();
    }
}
