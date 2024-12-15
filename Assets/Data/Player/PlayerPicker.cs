using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class PlayerPicker : MyBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.3f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }

    protected void OnTriggerEnter(Collider other)
    {
        //ItemDropCtrl itemDropCtrl = other.transform.GetComponent<ItemDropCtrl>();
        //if (itemDropCtrl == null) return;
        //itemDropCtrl.Despawn.DoDespawn();
    }
}
