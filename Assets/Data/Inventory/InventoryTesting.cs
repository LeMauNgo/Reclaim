using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class InventoryTesting : MyBehaviour
{
    private void Start()
    {
        //this.AddTestItems(ItemCode.Gold, 1000);
    }

    [ProButton]
    public virtual void AddTestItems(ItemCode itemCode, int count)
    {
        for (int i = 0; i < count; i++)
        {
            InventoriesManager.Instance.AddItem(itemCode, 1);
        }
    }

    [ProButton]
    public virtual void RemoveTestItems(ItemCode itemCode, int count)
    {
        for (int i = 0; i < count; i++)
        {
            InventoriesManager.Instance.RemoveItem(itemCode, 1);
        }
    }
}
