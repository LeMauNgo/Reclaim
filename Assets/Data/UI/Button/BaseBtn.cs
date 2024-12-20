using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseBtn : MyBehaviour
{
    [SerializeField] protected Button btn;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadButton();
    }
    protected virtual void LoadButton()
    {
        if (btn != null) return;
        this.btn = GetComponent<Button>();
        Debug.LogWarning(gameObject.name + " LoadButton");
    }
    protected virtual void Start()
    {
        this.AddOnclick();
    }
    protected virtual void AddOnclick()
    {

        this.btn.onClick.AddListener(Onclick);
    }
    protected abstract void Onclick();
}
