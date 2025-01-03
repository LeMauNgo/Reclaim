using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MySingleton<SoundManager>
{
    [SerializeField] protected SoundName bgName = SoundName.K391Ctrl;
    [SerializeField] protected MusicCtrl bgMusic;
    [SerializeField] protected SoundSpawnerCtrl ctrl;
    public SoundSpawnerCtrl Ctrl => ctrl;

    [Range(0f, 1f)]
    [SerializeField] protected float volumeMusic = 1f;

    [Range(0f, 1f)]
    [SerializeField] protected float volumeSfx = 1f;

    [SerializeField] protected List<MusicCtrl> listMusic;
    [SerializeField] protected List<SFXCtrl> listSfx;
    [SerializeField] protected List<SFXCtrl> listNPC;

    protected override void Awake()
    {
        base.Awake();
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        this.StartMusicBackground();
    }
    protected virtual void FixedUpdate()
    {
        this.VolumeMusicUpdating(this.volumeMusic);
        this.VolumeSfxUpdating(this.volumeSfx);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSoundSpawnerCtrl();
        this.LoadMusicCtrl();
    }

    protected virtual void LoadSoundSpawnerCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GameObject.FindAnyObjectByType<SoundSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadSoundSpawnerCtrl", gameObject);
    }    
    protected virtual void LoadMusicCtrl()
    {
        if (this.bgMusic != null) return;
        this.bgMusic = GetComponentInChildren<MusicCtrl>();
        Debug.Log(transform.name + ": LoadMusicCtrl", gameObject);
    }

    public virtual void StartMusicBackground()
    {
        if (this.bgMusic == null) this.bgMusic = this.CreateMusic(this.bgName);
        this.bgMusic.gameObject.SetActive(true);
    }

    public virtual void ToggleMusic()
    {
        if (this.bgMusic == null)
        {
            this.StartMusicBackground();
            return;
        }

        bool status = this.bgMusic.gameObject.activeSelf;
        this.bgMusic.gameObject.SetActive(!status);
    }


    public virtual MusicCtrl CreateMusic(SoundName soundName)
    {
        MusicCtrl soundPrefab = (MusicCtrl)this.ctrl.Prefabs.GetByName(soundName.ToString());
        return this.CreateMusic(soundPrefab);
    }

    public virtual MusicCtrl CreateMusic(MusicCtrl musicPrefab)
    {
        MusicCtrl newMusic = (MusicCtrl)this.ctrl.Spawner.Spawn(musicPrefab, Vector3.zero);
        this.AddMusic(newMusic);
        Debug.Log("Create");
        return newMusic;
    }

    public virtual void AddMusic(MusicCtrl newMusic)
    {
        if (this.listMusic.Contains(newMusic)) return;
        this.listMusic.Add(newMusic);
    }

    public virtual SFXCtrl CreateSfx(SoundName soundName, Vector3 position)
    {
        SFXCtrl soundPrefab = (SFXCtrl)this.ctrl.Prefabs.GetByName(soundName.ToString());

        SFXCtrl newSound =  this.CreateSfx(soundPrefab);
        newSound.transform.position = position;
        newSound.gameObject.SetActive(true);
        return newSound;
    }

    public virtual SFXCtrl CreateSfx(SFXCtrl sfxPrefab)
    {
        SFXCtrl newSound = (SFXCtrl)this.ctrl.Spawner.Spawn(sfxPrefab, Vector3.zero);
        this.AddSfx(newSound);
        return newSound;
    }

    public virtual void AddSfx(SFXCtrl newSound)
    {
        if (this.listSfx.Contains(newSound)) return;
        this.listSfx.Add(newSound);
    }

    public virtual void VolumeMusicUpdating(float volume)
    {
        this.volumeMusic = volume;
        foreach(MusicCtrl musicCtrl in this.listMusic)
        {
            musicCtrl.AudioSource.volume = this.volumeMusic;
        }
    }

    public virtual void VolumeSfxUpdating(float volume)
    {
        this.volumeSfx = volume;
        foreach (SFXCtrl sfxCtrl in this.listSfx)
        {
            sfxCtrl.AudioSource.volume = this.volumeSfx;
        }
    }
}
