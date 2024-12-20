using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSolider : PlayerAbstract
{
    private void Update()
    {
        this.SpawnSwat();
    }
    protected virtual void SpawnSwat()
    {
        if (this.playerCtrl.PlayerMana.GetCurrentMana() < 1) return;
        if (InputHotkeys.Instance.SpawnSwat())
        {
            SoliderCtrl prefab = SoliderSpawnerCtrl.Instance.Prefabs.GetByName("Swat");
            SoliderCtrl newEnemy = SoliderSpawnerCtrl.Instance.Spawner.Spawn(prefab, prefab.transform.position);
            newEnemy.gameObject.SetActive(true);
            this.playerCtrl.PlayerMana.DeductMana(1);
            //this.spawnedSolider.Add(newEnemy);
        }
    }
}
