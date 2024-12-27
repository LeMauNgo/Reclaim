using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatCtrl : SoliderCtrl
{
    public override string GetName()
    {
        return "Swat";
    }

    protected override void SetTypeArmy()
    {
        this.type = ArmyType.Friendly;
    }
}
