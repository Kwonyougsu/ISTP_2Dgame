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
        CurrentStat.target = baseStats.target;
        baseStats.isChase = true;
        CurrentStat.isChase = baseStats.isChase;
        UpdateSize();
        //Debug.Log(CurrentStat.isChase);
    }

    private void UpdateSize()
    {
        CurrentStat.size = baseStats.size;
        transform.localScale = new Vector3(CurrentStat.size, CurrentStat.size, 1f);
        //transform.localScale = new Vector3(2f,1f,1f);
    }

}
