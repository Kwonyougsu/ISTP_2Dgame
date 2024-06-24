using System;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = .5f;

    private PlayerStatsHandler statsHandler;
    private float timeSinceLastChange = float.MaxValue;
    private bool isAttacked = false;

    // ü���� ������ �� �� �ൿ���� �����ϰ� ���� ����
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;

    public float CurrentHealth { get; private set; }

    // get�� ������ ��ó�� ������Ƽ�� ����ϴ� ��
    // �̷��� �ϸ� �������� �������� �������� ���ƴٴϴٰ� ��ũ�� ������ ������ ���� �� �־��!
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

       // [�ּڰ��� 0, �ִ��� MaxHealth�� �ϴ� ����]
       CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
       Debug.Log("�¾Ҵ� �� ü�� " + CurrentHealth);
        
        if (CurrentHealth <= 0f)
        {
            Debug.Log("�׾��� �� ü��" + CurrentHealth);
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
