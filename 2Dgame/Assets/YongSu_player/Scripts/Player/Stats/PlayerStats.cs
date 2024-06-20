using UnityEngine;

public enum StatsChangeType
{
    Add, // 0
    Multiple, // 1
    Override, // 2
}
public class PlayerStats : MonoBehaviour
{

    public StatsChangeType statsChangeType;
    [Range(0, 100)] public int maxHealth;
    [Range(0f, 20f)] public float speed;
    public AttackSO attackSO;

    //public float HP;
    //public GameObject endpanel;
    //public GameObject endpanelbg;
    //private void Start()
    //{
    //    endpanel.SetActive(false);
    //    endpanelbg.SetActive(false);
    //    HP = 100f;
    //}
    //private void Update()
    //{
    //    LowHp();
    //}

    //public void LowHp(float damage = 0)
    //{
    //    HP -= damage;
        
    //    if (HP <= 0)
    //    {
    //        Time.timeScale = 0f;
    //        endpanel.SetActive(true);
    //        endpanelbg.SetActive(true);
    //    }
    //}
}
