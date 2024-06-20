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
    [Range(0, 100)] public int maxHealth;
    [Range(0f, 50f)] public float speed;
    public AttackSO attackSO;
}
