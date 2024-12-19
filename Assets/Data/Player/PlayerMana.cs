using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : PlayerAbstract
{
    [SerializeField] protected float currentMana = 10;
    [SerializeField] protected int maxMana = 15;
    [SerializeField] protected int speed = 2;
    protected void FixedUpdate()
    {
        this.ManaRegeneration();
    }
    protected virtual void ManaRegeneration()
    {
        this.currentMana += speed * Time.fixedDeltaTime;
        if(this.currentMana > maxMana) this.currentMana = maxMana;
    }
    protected virtual void DeductMana(int numberMana)
    {
        this.currentMana -= numberMana;
    }
    protected virtual float ManaRatio()
    {
        return this.currentMana/this.maxMana;
    }
}
