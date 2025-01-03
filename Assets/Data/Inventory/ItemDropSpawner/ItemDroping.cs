using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDroping : MyBehaviour
{
    [SerializeField] protected ItemDropCtrl ctrl;
    [SerializeField] protected float spawnHeight = 1.0f;
    [SerializeField] protected float forceAmount = 5.0f;

    protected virtual void OnEnable()
    {
        this.Droping();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponentInParent<ItemDropCtrl>();
        Debug.LogWarning(transform.name + ": LoadCtrl", gameObject);
    }

    protected virtual void Droping()
    {
        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), this.spawnHeight, Random.Range(-0.5f, 0.5f));
        transform.parent.position = spawnPosition;

        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = Mathf.Abs(randomDirection.y);
        ctrl.Rigidbody.AddForce(randomDirection * forceAmount, ForceMode.Impulse);
    }
}
