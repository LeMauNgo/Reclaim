using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BtnUpgradeSolider : BaseBtn
{
    [SerializeField] protected TextMeshProUGUI nextLevelGold;
    [SerializeField] protected TextMeshProUGUI levelTxt;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadNextLevelGold();
        this.LoadLevelTxt();
    }
    protected virtual void LoadNextLevelGold()
    {
        if (this.nextLevelGold != null) return;
        this.nextLevelGold = transform.Find("NextLevelGold").GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadNextLevelGold", gameObject);
    }
    protected virtual void LoadLevelTxt()
    {
        if (this.levelTxt != null) return;
        this.levelTxt = transform.parent.Find("LevelTxt").GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadLevelTxt", gameObject);
    }
    protected override void OnClick()
    {
        ArmySpawnerCtrl.Instance.ArmyManager.SoliderManager.Leveling();
    }
    private void FixedUpdate()
    {
        this.nextLevelGold.text = "Upgrade: " + ArmySpawnerCtrl.Instance.ArmyManager.SoliderManager.GetNextLevelGold().ToString();
        this.levelTxt.text = "Level: " + ArmySpawnerCtrl.Instance.ArmyManager.SoliderManager.CurrentLevel.ToString();
    }
}
