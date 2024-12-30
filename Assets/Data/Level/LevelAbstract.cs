using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelAbstract : MyBehaviour
{
    [SerializeField] protected int currentLevel = 1;
    public int CurrentLevel => currentLevel;

    [SerializeField] protected int maxLevel = 100;
}
