using UnityEngine;

public class MusicDespawn : Despawn<SoundCtrl>
{
    private void Reset()
    {
        this.ResetValue();
        this.LoadComponent();
    }

    protected virtual void ResetValue()
    {
        this.isDespawnByTime = false;
    }
}
