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

    public float CurrentHealth { get; set; }
    public float MaxHealth{ get; set; }

    private void OnEnable()
    {   
        CurrentHealth = MaxHealth;
    }

    private void Awake()
    {
        statsHandler = GetComponent<EnemyStatHandler>();
        MaxHealth = statsHandler.CurrentStat.maxHealth;
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
        //Debug.Log($"ChangeHealth - CurrentHealth: {CurrentHealth}");
        //Debug.Log(change);
        if (change < 0)
        {            
            if (timeSinceLastChange < healthChangeDelay)
            {
                return false;
            }            
            timeSinceLastChange = 0f;

            CurrentHealth += change;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
            OnDamage?.Invoke();
            isAttacked = true;
        }

        if (CurrentHealth <= 0f)
        {
            CallDeath();
            return true;
        }              
      
        return true;
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }

    private void OnDisable()
    {
        MaxHealth = statsHandler.CurrentStat.maxHealth;
    }

}
