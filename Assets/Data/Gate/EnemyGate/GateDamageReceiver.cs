using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDamageReceiver : EnemyDamageReceiver
{
    private void OnEnable()
    {
        this.currentHP = 200;
        this.maxHP = 200;
    }
    protected override void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = transform.GetComponent<CapsuleCollider>();
        this.capsuleCollider.radius = 3f;
        this.capsuleCollider.height = 10;
        this.capsuleCollider.center = new Vector3(0, 0, -1);
        this.capsuleCollider.isTrigger = true;
        this.capsuleCollider.direction = 0;
        Debug.LogWarning(gameObject.name + "LoadCapsuleCollider", gameObject);
    }
    protected override void OnDead()
    {
        if (!GameManager.Instance.IsPlaying()) return;
        transform.parent.gameObject.SetActive(false);
        UIManager.Instance.UICenter.ShowUiCenter("Win");
        GameManager.Instance.SetGamePlay(false);
        EnemySpawnerCtrl.Instance.EnemyWave.KillAllEnemy();
    }
}
