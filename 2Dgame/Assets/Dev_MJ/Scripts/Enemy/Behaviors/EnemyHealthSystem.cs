using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    // 피격당했을때 재생할 사운드
    [SerializeField] private AudioClip DamageClip;

    // 무적시간을 위한 필드 (체력 변화까지의 딜레이)
    [SerializeField] private float healthChangeDelay = 0.5f;     

    private float timeSinceLastChange = float.MaxValue;

    // enemy 능력치 캐싱
    private EnemyStatHandler statsHandler;

    // 공격을 받았을때
    private bool isAttacked = false;

    public event Action OnDamage;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;

    public float CurrentHealth { get; private set; }
    public float MaxHealth => statsHandler.CurrentStat.maxHealth;

    private void Awake()
    {
        statsHandler = GetComponent<EnemyStatHandler>();
    }

    private void OnEnable()
    {
        CurrentHealth = MaxHealth;
    }

    private void Start()
    {       
        CurrentHealth = MaxHealth;

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

    // 공격을 받았을 때
    public bool ChangeHealth(float change)
    {

        if (change < 0)
        {            
            if (timeSinceLastChange < healthChangeDelay)
            {
                return false;
            }            
            timeSinceLastChange = 0f;

            CurrentHealth += change;
            // [최솟값을 0, 최댓값을 MaxHealth로 하는 구문]
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

            //Debug.Log($"몬스터 체력 CurrentHealth: {CurrentHealth}, MaxHealth: {MaxHealth}");

            OnDamage?.Invoke();
            isAttacked = true;
            //Debug.Log("맞았다" );
            // 피격 이펙트 사운드가 있다면 재생
            //if (DamageClip) SoundManager.PlayClip(DamageClip);
        }
        
        if (CurrentHealth <= 0f)
        {
            CallDeath();
            //Debug.Log("몬스터 죽었다");
            return true;

        }              
      
        return true;
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }

}
