using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TowerManager : MyBehaviour
{
    [SerializeField] protected ArmyManager armyManager;

    [SerializeField] protected List<TowerCtrl> towerAlive;
    public List<TowerCtrl> TowerAlive => towerAlive;

    [Header("EnemyTowerAlive")]
    [SerializeField] protected List<TowerCtrl> enemyTowerAlive;
    public List<TowerCtrl> EnemyTowerAlive => enemyTowerAlive;

    [Header("AllyTowerAlive")]
    [SerializeField] protected int currentLevel = 1;
    public int CurrentLevel => currentLevel;

    [SerializeField] protected int maxLevel = 100;
    [SerializeField] protected int nextLevelGold;
    [SerializeField] protected List<TowerCtrl> allyTowerAlive;
    public List<TowerCtrl> AllyTowerAlive => allyTowerAlive;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadArmyManager();
    }
    protected virtual void LoadArmyManager()
    {
        if (this.armyManager != null) return;
        this.armyManager = GetComponent<ArmyManager>();
        Debug.LogWarning(gameObject.name + " LoadArmyManager", gameObject);
    }
    public virtual void LoadEnemyTower()
    {
        this.towerAlive = this.armyManager.ArmyAlive.OfType<TowerCtrl>().ToList();
        this.enemyTowerAlive = this.towerAlive.Where(s => s.GetTypeArmy() == ArmyType.Enemy).ToList();
        this.allyTowerAlive = this.towerAlive.Where(s => s.GetTypeArmy() == ArmyType.Ally).ToList();
    }
    // ---------------Level----------------------------------
    protected virtual int GetCurrentGold()
    {
        return InventoriesManager.Instance.Currency().FindItem(ItemCode.Gold).itemCount;
    }
    protected virtual void DeductGold(int gold)
    {
        InventoriesManager.Instance.RemoveItem(ItemCode.Gold, gold);
    }

    public virtual void Leveling()
    {
        if (this.currentLevel >= this.maxLevel) return;
        if (this.GetCurrentGold() < this.GetNextLevelGold()) return;
        this.DeductGold(this.GetNextLevelGold());
        this.currentLevel++;
    }

    public virtual int GetNextLevelGold()
    {
        return this.nextLevelGold = this.currentLevel * 300;
    }
}
