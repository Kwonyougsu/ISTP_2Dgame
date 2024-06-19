using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    // 피격당했을때 재생할 사운드
    [SerializeField] private AudioClip DamageClip;

    // 무적시간을 위한 필드 (체력 변화까지의 딜레이)
    [SerializeField] private float healthChangeDelay = 0.3f;
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

    private void Start()
    {       
        CurrentHealth = MaxHealth;

    }

    // 공격을 받았을 때
    public void ChangeHealth(float change)
    {

        CurrentHealth += change;
        // [최솟값을 0, 최댓값을 MaxHealth로 하는 구문]
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);      

        if (CurrentHealth <= 0f)
        {
            CallDeath();
            Debug.Log("죽었다");
            return;

        }      
        else
        {
     
            OnDamage?.Invoke();
            isAttacked = true;
            Debug.Log("맞았다");
            // 피격 이펙트 사운드가 있다면 재생
            //if (DamageClip) SoundManager.PlayClip(DamageClip);

        }
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }

}
