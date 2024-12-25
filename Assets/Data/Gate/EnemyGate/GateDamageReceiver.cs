using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDamageReceiver : MyBehaviour
{
    //private void OnEnable()
    //{
    //    this.currentHP = 200;
    //    this.maxHP = 200;
    //}
    //protected override void OnDead()
    //{
    //    if (!GameManager.Instance.IsPlaying()) return;
    //    transform.parent.gameObject.SetActive(false);
    //    UIManager.Instance.UICenter.ShowUiCenter("Win");
    //    GameManager.Instance.SetGamePlay(false);
    //    EnemySpawnerCtrl.Instance.EnemyWave.KillAllEnemy();
    //}

    //protected override void LoadCollider()
    //{
    //    if (this._collider != null) return;
    //    this._collider = transform.GetComponent<CapsuleCollider>();
    //    CapsuleCollider capsuleCollider = (CapsuleCollider)this._collider;
    //    capsuleCollider.radius = 3f;
    //    capsuleCollider.height = 10;
    //    capsuleCollider.center = new Vector3(0, 0, -1);
    //    capsuleCollider.isTrigger = true;
    //    capsuleCollider.direction = 0;
    //    Debug.LogWarning(gameObject.name + "LoadCollider", gameObject);
    //}
}
