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
            ArmyCtrl prefab = ArmySpawnerCtrl.Instance.Prefabs.GetByName("Swat");
            ArmyCtrl newEnemy = ArmySpawnerCtrl.Instance.Spawner.Spawn(prefab, new Vector3(-42,0,-39));
            ArmySpawnerCtrl.Instance.ArmyManager.AddEnemy(newEnemy);
            newEnemy.gameObject.SetActive(true);
            this.playerCtrl.PlayerMana.DeductMana(1);
            //this.spawnedSolider.Add(newEnemy);

        }
    }
}
