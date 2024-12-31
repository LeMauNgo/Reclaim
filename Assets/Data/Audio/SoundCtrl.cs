using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class SoundCtrl : PoolObj
{
    [SerializeField] protected AudioSource audioSource;
    public AudioSource AudioSource => audioSource;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAudioSource();
    }

    protected virtual void LoadAudioSource()
    {
        if (this.audioSource != null) return;
        this.audioSource = GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadAudioSource", gameObject);
    }
}
