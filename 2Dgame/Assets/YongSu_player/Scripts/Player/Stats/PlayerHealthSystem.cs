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

    public float CurrentHealth { get; private set; }

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
    public void Heal(float value)
    {
        CurrentHealth += value;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        UpdateHealthBar();
    }
}
