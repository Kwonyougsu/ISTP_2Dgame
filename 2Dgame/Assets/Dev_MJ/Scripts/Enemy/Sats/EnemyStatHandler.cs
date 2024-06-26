using UnityEngine;

public class EnemyStatHandler : MonoBehaviour
{
    [SerializeField] private EnemyStat baseStats;

    public EnemyStat CurrentStat { get; private set; }

    private void Awake()
    {
        UpdateEnemyStat();
    }

    private void UpdateEnemyStat()
    {        
        EnemyAttackSO attackSO = null;
        
        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        CurrentStat = new EnemyStat { attackSO = attackSO };
        
        //기본 능력치 세팅        
        CurrentStat.maxHealth = baseStats.maxHealth;
        CurrentStat.speed = baseStats.speed;
        baseStats.isChase = true;
        CurrentStat.target = baseStats.target;        
        CurrentStat.isBoss = baseStats.isBoss;
        CurrentStat.isChase = baseStats.isChase;
    }
}
