using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    // �ǰݴ������� ����� ����
    [SerializeField] private AudioClip DamageClip;

    // �����ð��� ���� �ʵ� (ü�� ��ȭ������ ������)
    [SerializeField] private float healthChangeDelay = 0.3f;
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

    private void Start()
    {       
        CurrentHealth = MaxHealth;

    }

    // ������ �޾��� ��
    public void ChangeHealth(float change)
    {

        CurrentHealth += change;
        // [�ּڰ��� 0, �ִ��� MaxHealth�� �ϴ� ����]
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);      

        if (CurrentHealth <= 0f)
        {
            CallDeath();
            Debug.Log("�׾���");
            return;

        }      
        else
        {
     
            OnDamage?.Invoke();
            isAttacked = true;
            Debug.Log("�¾Ҵ�");
            // �ǰ� ����Ʈ ���尡 �ִٸ� ���
            //if (DamageClip) SoundManager.PlayClip(DamageClip);

        }
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }

}
