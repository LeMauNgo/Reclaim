using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MyBehaviour
{
    [SerializeField] protected int currentWeaponIndex = 0;
    [SerializeField] protected List<WeaponsCtrl> weapons;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWeapons();
    }

    protected virtual void LoadWeapons()
    {
        if (this.weapons.Count > 0) return;
        foreach (Transform child in transform)
        {
            WeaponsCtrl weaponAbtract = child.GetComponent<WeaponsCtrl>();
            if (weaponAbtract == null) continue;
            this.weapons.Add(weaponAbtract);
        }
        Debug.Log(transform.name + ": LoadWeapons", gameObject);
    }

    public virtual WeaponsCtrl GetCurrentWeapon()
    {
        return this.weapons[this.currentWeaponIndex];
    }
}
