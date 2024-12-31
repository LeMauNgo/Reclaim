using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class TxtLevel : MyBehaviour
{
    [SerializeField] protected TextMeshPro textPro;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTextPro();
    }
    protected virtual void LoadTextPro()
    {
        if (this.textPro != null) return;
        this.textPro = GetComponent<TextMeshPro>();
        Debug.Log(transform.name + ": LoadTextPro", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        this.UpdateLevel();
    }

    protected virtual void UpdateLevel()
    {
        this.textPro.text = this.GetLevel();
    }

    protected abstract string GetLevel();
}
