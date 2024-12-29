using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnItemInventory : BaseBtn
{
    [SerializeField] protected TextMeshProUGUI itemNameTxt;
    [SerializeField] protected TextMeshProUGUI itemCountTxt;
    [SerializeField] protected Image logo;

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;
    //private void OnEnable()
    //{
    //    this.itemNameTxt.text = this.itemInventory.GetItemName().ToString();
    //    this.itemCountTxt.text = this.itemInventory.itemCount.ToString();
    //    this.logo.sprite = this.itemInventory.ItemProfile.logo;
    //}
    protected override void LoadComponent()
    {
        //base.LoadComponent();
        //this.LoadItemNameTxt();
        //this.LoadItemCountTxt();
        //this.LoadLogo();

    }
    protected virtual void LoadItemNameTxt()
    {
        if (this.itemNameTxt != null) return;
        this.itemNameTxt = transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(gameObject.name + "LoadItemNameTxt", gameObject);
    }    
    protected virtual void LoadItemCountTxt()
    {
        if (this.itemCountTxt != null) return;
        this.itemCountTxt = transform.Find("ItemCount").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(gameObject.name + "LoadItemCountTxt", gameObject);
    }
    protected virtual void LoadLogo()
    {
        if (this.logo != null) return;
        this.logo = GetComponent<Image>();
        Debug.LogWarning(gameObject.name + "LoadLogo", gameObject);
    }
    public virtual void SetItem(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }

    protected override void Onclick()
    {
        throw new System.NotImplementedException();
    }
}
