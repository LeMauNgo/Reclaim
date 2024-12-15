using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;

public abstract class Spawner<T> : MyBehaviour where T : PoolObj
{
    [SerializeField] protected int spawnCount = 0;
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<T> inPoolObjs = new();
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHolder();
    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.LogWarning(gameObject.name + "LoadHolder", gameObject);
    }
    public virtual T Spawn(T prefab)
    {
        T newObject = this.GetObjFromPool(prefab);
        if (newObject == null)
        {
            newObject = Instantiate(prefab);
            newObject.transform.parent = this.holder;
            this.spawnCount++;
            this.UpdateName(prefab.transform, newObject.transform);
        }

        return newObject;
    }

    public virtual T Spawn(T prefab, Vector3 postion)
    {
        T newObject = this.Spawn(prefab);
        newObject.transform.position = postion;
        return newObject;
    }

    public virtual T Spawn(T prefab, Vector3 postion, Quaternion rotation)
    {
        T newObject = this.Spawn(prefab, postion);
        newObject.transform.rotation = rotation;
        return newObject;
    }

    public virtual void Despawn(T obj)
    {
        if (obj is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(false);
            this.AddObjectToPool(obj);
        }
    }

    protected virtual void AddObjectToPool(T obj)
    {
        this.inPoolObjs.Add(obj);
    }

    protected virtual void RemoveObjectFromPool(T obj)
    {
        this.inPoolObjs.Remove(obj);
    }

    protected virtual void UpdateName(Transform prefab, Transform newObject)
    {
        newObject.name = prefab.name + "_" + this.spawnCount;
    }

    protected virtual T GetObjFromPool(T prefab)
    {
        foreach (T inPoolObj in this.inPoolObjs)
        {
            if (prefab.GetName() == inPoolObj.GetName())
            {
                this.RemoveObjectFromPool(inPoolObj);
                return inPoolObj;
            }
        }

        return null;
    }
}