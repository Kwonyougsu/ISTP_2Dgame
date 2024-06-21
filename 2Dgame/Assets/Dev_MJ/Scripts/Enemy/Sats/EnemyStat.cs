using System;
using UnityEngine;

[Serializable]
public class EnemyStat
{    
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;
    [Range(1f, 10f)] public float size;
    public bool isChase;
    public LayerMask target;

    public EnemyAttackSO attackSO;
}
