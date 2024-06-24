using UnityEngine;
using System.Collections.Generic;

public class PlayerStatsHandler : MonoBehaviour
{
    // 기본 스탯과 버프 스탯들의 능력치를 종합해서 스탯을 계산하는 컴포넌트
    [SerializeField] private PlayerStats baseStats;
    
    [field:SerializeField]public PlayerStats CurrentStat { get; private set; } = new();
    public List<PlayerStats> statsModifiers = new List<PlayerStats>();
    public ItemData itemData;
    private readonly float MinSpeed = 5f;
    private readonly int MinMaxHealth = 10;

    private void Awake()
    {        
        UpdateCharacterStat();
    }
    private void Update()
    {
        moveSpeed();
    }
    public void UpdateCharacterStat()
    {
        CurrentStat.statsChangeType = baseStats.statsChangeType;
        CurrentStat.maxHealth = baseStats.maxHealth;
        CurrentStat.speed = baseStats.speed;
        CurrentStat.attackSO = Instantiate(baseStats.attackSO);

        ApplyStatModifiers(baseStats);
    }

    private void ApplyStatModifiers(PlayerStats modifier)
    {
        UpdateBasicStats(modifier);
    }

    private void UpdateBasicStats(PlayerStats modifier)
    {
        CurrentStat.maxHealth = Mathf.Max(CurrentStat.maxHealth + (10 * itemData.itemstack[2]), MinMaxHealth);
        CurrentStat.speed = Mathf.Max(CurrentStat.speed + ((5*0.2f) * itemData.itemstack[1]), MinSpeed);
    }
    void moveSpeed()
    {
        CurrentStat.speed = 5 + ((5 * 0.2f) * itemData.itemstack[1]) + (GameManager.Instance.upgradeStatData.statLv[1]*0.25f);
    }
}