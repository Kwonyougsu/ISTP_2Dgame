using System;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] private AudioClip DamageClip;
    [SerializeField] private float healthChangeDelay = 0.5f;     

    private float timeSinceLastChange = float.MaxValue;
    private EnemyStatHandler statsHandler;
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
