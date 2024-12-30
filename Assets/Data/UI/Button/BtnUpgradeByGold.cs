using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BtnUpgradeByGold : BaseBtn
{
    [SerializeField] protected int currentLevel = 1;
    public int CurrentLevel => currentLevel;

    [SerializeField] protected int maxLevel = 100;
    [SerializeField] protected int nextLevelGold;
    [SerializeField] protected TextMeshProUGUI textMeshProUGUI;
    private void OnEnable()
    {
        this.textMeshProUGUI.text = "Upgrade: " + this.GetNextLevelGold().ToString();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTextMeshProUGUI();
    }
    protected virtual void LoadTextMeshProUGUI()
    {
        if (this.textMeshProUGUI != null) return;
        this.textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(gameObject.name + " LoadTextMeshProUGUI", gameObject);
    }
    protected virtual int GetCurrentGold()
    {
        return InventoriesManager.Instance.Currency().FindItem(ItemCode.Gold).itemCount;
    }
    protected virtual void DeductGold(int gold)
    {
        InventoriesManager.Instance.RemoveItem(ItemCode.Gold, gold);
    }

    protected override void Onclick()
    {
        this.Leveling();
    }
    protected virtual void Leveling()
    {
        if (this.currentLevel >= this.maxLevel) return;
        if (this.GetCurrentGold() < this.GetNextLevelGold()) return;
        this.DeductGold(this.GetNextLevelGold());
        this.currentLevel++;
        this.textMeshProUGUI.text = "Upgrade: " + this.GetNextLevelGold().ToString();
    }

    protected abstract int GetNextLevelGold();
}
