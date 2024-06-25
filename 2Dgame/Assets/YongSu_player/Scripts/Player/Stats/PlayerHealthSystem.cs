using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = .5f;
    [SerializeField] private Image healthBar;

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
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        statsHandler = GetComponent<PlayerStatsHandler>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        CurrentHealth = statsHandler.CurrentStat.maxHealth;
        UpdateHealthBar();
    }

    private void Update()
    {
        //if (isAttacked && timeSinceLastChange < healthChangeDelay)
        //{
        //    timeSinceLastChange += Time.deltaTime;
        //    if (timeSinceLastChange >= healthChangeDelay)
        //    {
        //        OnInvincibilityEnd?.Invoke();
        //        isAttacked = false;
        //    }
        //}
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
        timeSinceLastChange = 0f;
        spriteRenderer.color = Color.red;
        Invoke(nameof(ResetSpriteColor), 0.5f);
        UpdateHealthBar();
        //Debug.Log("�¾Ҵ� �� ü�� " + CurrentHealth);

        if (CurrentHealth <= 0f)
        {
            Debug.Log("�׾��� �� ü��" + CurrentHealth);
            endpanel.SetActive(true);
            endpanelbg.SetActive(true);
            //CallDeath();
            Time.timeScale = 0f;
            return true;
        }
        
        //if (change >= 0)
        //{
        //    OnHeal?.Invoke();
        //}
        //else
        //{
        //    OnDamage?.Invoke();
        //    isAttacked = true;
        //}


        return true;
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }

    private void ResetSpriteColor()
    {
        spriteRenderer.color = Color.white;
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = CurrentHealth / MaxHealth;
        }
    }
}
