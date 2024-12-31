using UnityEngine;

public class BtnMusicToggle : BaseBtn
{
    protected virtual void LateUpdate()
    {
        this.HotkeyToogleMusic();
    }

    protected override void OnClick()
    {
        SoundManager.Instance.ToggleMusic();
    }

    protected virtual void HotkeyToogleMusic()
    {
        //if (InputHotkeys.Instance.isToogleMusic) SoundManager.Instance.ToggleMusic();
    }
}
