using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch15_nonPBRCtrl : SoliderCtrl
{ 
    public override string GetName()
    {
        return "Ch15_nonPBR";
    }

    protected override void SetTypeArmy()
    {
        this.type = ArmyType.Enemy;
    }
}
