using System;
using System.Collections;
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
            Debug.Log("실행");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {
            Debug.Log("몬스터 공격");
        }
    }
}
