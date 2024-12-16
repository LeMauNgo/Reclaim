using UnityEngine;

public abstract class SFXCtrl : SoundCtrl
{
    private void Reset()
    {
        this.LoadComponent();
        this.ResetValue();

    }

    protected virtual void ResetValue()
    {
        this.audioSource.spatialBlend = 1;
    }
}
