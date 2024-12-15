using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MyBehaviour : MonoBehaviour
{
    private void Reset()
    {
        this.LoadComponent();
    }
    private void Awake()
    {
        this.LoadComponent();
    }
    protected virtual void LoadComponent()
    {


    }
}
