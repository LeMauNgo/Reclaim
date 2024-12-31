using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoliderManager : MyBehaviour
{
    [SerializeField] protected ArmyManager armyManager;

    [SerializeField] protected List<SoliderCtrl> soliderAlive;
    public List<SoliderCtrl> SoliderAlive => soliderAlive;
    [SerializeField] protected List<SoliderCtrl> enemySoliderAlive;
    public List<SoliderCtrl> EnemySoliderAlive => enemySoliderAlive;

    [Header("AllySoliderAlive")]
    [SerializeField] protected int currentLevel = 1;
    public int CurrentLevel => currentLevel;

    [SerializeField] protected int maxLevel = 100;
    [SerializeField] protected int nextLevelGold;
    [SerializeField] protected List<SoliderCtrl> allySoliderAlive;
    public List<SoliderCtrl> AllySoliderAlive => allySoliderAlive;
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
    public virtual void LoadSolider()
    {
        this.soliderAlive = this.armyManager.ArmyAlive.OfType<SoliderCtrl>().ToList();
        this.enemySoliderAlive = soliderAlive.Where(s => s.GetTypeArmy() == ArmyType.Enemy).ToList();
        this.allySoliderAlive = soliderAlive.Where(s => s.GetTypeArmy() == ArmyType.Ally).ToList();
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
        return this.nextLevelGold = this.currentLevel * 100;
    }
}
