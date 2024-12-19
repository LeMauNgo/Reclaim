using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MySingleton<GameManager> 
{
    [SerializeField] protected bool isPlaying;
    private void OnEnable()
    {
        this.isPlaying = true;
    }
    public virtual bool IsPlaying()
    {
        return isPlaying;
    }
    public virtual void SetGamePlay(bool isPlay)
    {
        this.isPlaying = isPlay;
    }
}
