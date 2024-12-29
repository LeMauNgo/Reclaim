using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInventory : UICenterCtrl
{
    [SerializeField] protected bool isShow;
    public bool IsShow => isShow;

    [SerializeField] protected BtnItemInventory defaultItemInventoryUI;
    [SerializeField] protected List<BtnItemInventory> btnItems = new();

    protected virtual void FixedUpdate()
    {
        this.ItemsUpdating();

    }

    protected virtual void LateUpdate()
    {
        this.HotkeyToogleInventory();
    }

    private void Start()
    {
        this.HideDefaultItemInventory();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBtnItemInventory();
        this.LoadShowHide();
    }

    protected virtual void LoadBtnItemInventory()
    {
        if (this.defaultItemInventoryUI != null) return;
        this.defaultItemInventoryUI = GetComponentInChildren<BtnItemInventory>();
        Debug.Log(transform.name + ": LoadBtnItemInventory", gameObject);
    }

    public virtual void Show()
    {
        this.isShow = true;
        this.uICenter.ShowUiCenter(transform.name);
    }

    public virtual void Hide()
    {
        this.uICenter.HideUiCenter();
        this.isShow = false;
    }

    public virtual void Toggle()
    {
        if (this.isShow) this.Hide();
        else this.Show();
    }

    protected virtual void HideDefaultItemInventory()
    {
        this.defaultItemInventoryUI.gameObject.SetActive(false);
    }

    protected virtual void ItemsUpdating()
    {
        if (!this.isShow) return;

        InventoryCtrl itemInvCtrl = InventoriesManager.Instance.Item();

        BtnItemInventory newBtnItem;
        foreach (ItemInventory itemInventory in itemInvCtrl.Items)
        {
            newBtnItem = this.GetExistItem(itemInventory);
            if (newBtnItem == null)
            {
                newBtnItem = Instantiate(this.defaultItemInventoryUI);
                newBtnItem.transform.SetParent(this.defaultItemInventoryUI.transform.parent);
                newBtnItem.SetItem(itemInventory);
                newBtnItem.transform.localScale = new Vector3(1, 1, 1);
                newBtnItem.gameObject.SetActive(true);
                newBtnItem.name = itemInventory.GetItemName() + "-" + itemInventory.ItemID;
                this.btnItems.Add(newBtnItem);
            }
        }
    }

    protected virtual BtnItemInventory GetExistItem(ItemInventory itemInventory)
    {
        foreach (BtnItemInventory itemInvUI in this.btnItems)
        {
            if (itemInvUI.ItemInventory.ItemID == itemInventory.ItemID) return itemInvUI;
        }
        return null;
    }
    protected virtual void HotkeyToogleInventory()
    {
        if (InputHotkeys.Instance.IsToogleInventoryUI) this.Toggle();
    }
}
