using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberGold : MyBehaviour
{
    [SerializeField] protected TextMeshProUGUI numberGoldTxt;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadNumberGoldTxt();
    }
    protected virtual void LoadNumberGoldTxt()
    {
        if (this.numberGoldTxt != null) return;
        this.numberGoldTxt = GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(gameObject.name + " LoadNumberGoldTxt", gameObject);
    }
    private void FixedUpdate()
    {
        ItemInventory gold = InventoriesManager.Instance.GetByCodeName(InventoryType.Currency).FindItem(ItemCode.Gold);
        if (gold == null) return;
        this.numberGoldTxt.text = gold.itemCount.ToString();
    }
}
