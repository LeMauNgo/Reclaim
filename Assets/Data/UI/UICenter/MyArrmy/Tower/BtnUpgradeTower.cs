using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnUpgradeTower : BtnUpgradeByGold
{
    protected override int GetNextLevelGold()
    {
        return this.nextLevelGold = this.currentLevel * 300;
    }
}
