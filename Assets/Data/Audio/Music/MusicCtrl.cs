using UnityEngine;

public abstract class MusicCtrl : SoundCtrl
{
    private void Reset()
    {
        this.LoadComponent();
        this.ResetValue();

    }

    private void ResetValue()
    {

        this.audioSource.loop = true;
    }
}
