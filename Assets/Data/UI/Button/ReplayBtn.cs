using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayBtn : BaseBtn
{
    protected override void Onclick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
