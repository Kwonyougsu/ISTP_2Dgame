using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    // �ǰݴ������� ����� ����
    [SerializeField] private AudioClip DamageClip;

    // �����ð��� ���� �ʵ� (ü�� ��ȭ������ ������)
    [SerializeField] private float healthChangeDelay = 0.5f;     

    private float timeSinceLastChange = float.MaxValue;

    // enemy �ɷ�ġ ĳ��
    private EnemyStatHandler statsHandler;

    // ������ �޾�����
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

    // ������ �޾��� ��
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
            // [�ּڰ��� 0, �ִ��� MaxHealth�� �ϴ� ����]
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

            //Debug.Log($"���� ü�� CurrentHealth: {CurrentHealth}, MaxHealth: {MaxHealth}");

            OnDamage?.Invoke();
            isAttacked = true;
            //Debug.Log("�¾Ҵ�" );
            // �ǰ� ����Ʈ ���尡 �ִٸ� ���
            //if (DamageClip) SoundManager.PlayClip(DamageClip);
        }
        
        if (CurrentHealth <= 0f)
        {
            CallDeath();
            //Debug.Log("���� �׾���");
            return true;

        }              
      
        return true;
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }

}
