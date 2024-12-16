using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDespawn : Despawn<SoundCtrl>
{
    private void Reset()
    {
        this.LoadComponent();
    }

    protected virtual void ResetValue()
    {
        this.timeLife = 2f;
        this.currentTime = 2f;
    }
}
