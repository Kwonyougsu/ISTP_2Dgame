using System;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject AttackPrefab;
    public Transform CloseAttackPos;
    public PlayerStats Stats;
  
    private void Awake()
    {
        Stats = GetComponent<PlayerStats>();
    }
    private void Start()
    {
        StartCoroutine(CloseAttack());  
    }
        
    IEnumerator CloseAttack()
    {
        while (Stats.HP > 0)
        {
            closeAttack();
            yield return new WaitForSeconds(1f);//공격 주기
        }
        Debug.Log("끝남");
    }


    private void closeAttack()
    {
        GameObject Attack = Instantiate(AttackPrefab);
        Attack.transform.position =new Vector3(CloseAttackPos.position.x, CloseAttackPos.position.y);
        StartCoroutine(EndAttack(Attack, 0.5f)); //공격 유지시간
    }

    IEnumerator EndAttack(GameObject Attack,float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(Attack);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject attack = collision.gameObject;

        if (attack.CompareTag("Enemy"))
        {
            EnemyStatHandler enemyHealth = attack.GetComponent<EnemyStatHandler>();
            if (enemyHealth != null)
            {
                enemyHealth.CurrentStat.maxHealth -= (int)Stats.Power;
                Debug.Log("체력 몬스터 체력" + enemyHealth.CurrentStat.maxHealth);
            }

        }
    }
}
