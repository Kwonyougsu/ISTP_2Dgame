using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = 0.5f;
    [SerializeField] private Image healthBar;

    private PlayerStatsHandler statsHandler;
    private float timeSinceLastChange = float.MaxValue;
    private bool isAttacked = false;

    public float CurrentHealth { get; private set; }

    public float MaxHealth => statsHandler.CurrentStat.maxHealth;

    public GameObject endpanel;
    public GameObject endpanelbg;
    private SpriteRenderer spriteRenderer;

    private RectTransform healthBarRectTransform;
    private Vector3 hpBarWorldPos = new Vector3(0, -1, 0);

    private void Awake()
    {
        statsHandler = GetComponent<PlayerStatsHandler>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBarRectTransform = healthBar.GetComponent<RectTransform>();
    }

    private void Update()
    {
        UpdateHealthBarPosition();
    }

    private void Start()
    {
        CurrentHealth = statsHandler.CurrentStat.maxHealth;
        UpdateHealthBar();
    }


    public bool PlayerChangeHealth(float change)
    {
       CurrentHealth -= change;

       CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        timeSinceLastChange = 0f;
        spriteRenderer.color = Color.red;
        Invoke(nameof(ResetSpriteColor), 0.5f);
        UpdateHealthBar();

        if (CurrentHealth <= 0f)
        {
            Debug.Log("�׾��� �� ü��" + CurrentHealth);
            endpanel.SetActive(true);
            endpanelbg.SetActive(true);
            //CallDeath();
            Time.timeScale = 0f;
            return true;
        }
        return true;
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

    private void UpdateHealthBarPosition()
    {
        if (healthBarRectTransform != null)
        {
            // 플레이어 위치를 기준으로 healthBar의 위치 업데이트
            Vector3 worldPosition = transform.position + hpBarWorldPos;
            healthBarRectTransform.position = worldPosition;
        }
    }

    public void Heal(float value)
    {
        CurrentHealth += value;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        UpdateHealthBar();
    }
}
