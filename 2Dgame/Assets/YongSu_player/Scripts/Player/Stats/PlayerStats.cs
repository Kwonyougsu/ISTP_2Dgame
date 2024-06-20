using System;
using UnityEngine;


public enum StatsChangeType
{
    Add, // 0
    Multiple, // 1
    Override, // 2
}
[Serializable]
public class PlayerStats 
{
    public StatsChangeType statsChangeType;
    public int maxHealth;
    public float speed;
    public AttackSO attackSO;
}
