using System;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = .5f;

    private PlayerStatsHandler statsHandler;
    private float timeSinceLastChange = float.MaxValue;
    private bool isAttacked = false;

    // 체력이 변했을 때 할 행동들을 정의하고 적용 가능
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;

    public float CurrentHealth { get; private set; }

    // get만 구현된 것처럼 프로퍼티를 사용하는 것
    // 이렇게 하면 데이터의 복제본이 여기저기 돌아다니다가 싱크가 깨지는 문제를 막을 수 있어요!
    public float MaxHealth => statsHandler.CurrentStat.maxHealth;

    public GameObject endpanel;
    public GameObject endpanelbg;

    private Animator _animator;

    private void Awake()
    {
        statsHandler = GetComponent<PlayerStatsHandler>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        CurrentHealth = statsHandler.CurrentStat.maxHealth;
    }

    private void Update()
    {
        if (isAttacked && timeSinceLastChange < healthChangeDelay)
        {
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange >= healthChangeDelay)
            {
                OnInvincibilityEnd?.Invoke();
                isAttacked = false;
            }
        }
    }

    public bool PlayerChangeHealth(float change)
    {
       //if (timeSinceLastChange < healthChangeDelay)
       //{
       //     return false;
       //}
       //timeSinceLastChange = 0f;

       CurrentHealth -= change;

       // [최솟값을 0, 최댓값을 MaxHealth로 하는 구문]
       CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
       Debug.Log("맞았다 내 체력 " + CurrentHealth);
        
        if (CurrentHealth <= 0f)
        {
            Debug.Log("죽었다 내 체력" + CurrentHealth);
            endpanel.SetActive(true);
            endpanelbg.SetActive(true);
            CallDeath();
            Time.timeScale = 0f;
            return true;
        }
        
        if (change >= 0)
        {
            OnHeal?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();
            isAttacked = true;
            _animator.SetTrigger("Player_hit");
        }


        return true;
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }
}
