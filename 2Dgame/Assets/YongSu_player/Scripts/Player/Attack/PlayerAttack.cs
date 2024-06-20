using System;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject AttackPrefab;
    public Transform CloseAttackPos;
  
    private void Start()
    {
        StartCoroutine(CloseAttack());  
    }
        
    IEnumerator CloseAttack()
    {
        while (true)
        {
            closeAttack();
            yield return new WaitForSeconds(1f);//���� �ֱ�
        }
    }


    private void closeAttack()
    {
        GameObject Attack = Instantiate(AttackPrefab);
        Attack.transform.position =new Vector3(CloseAttackPos.position.x, CloseAttackPos.position.y);
        StartCoroutine(EndAttack(Attack, 0.15f)); //���� �����ð�
    }

    IEnumerator EndAttack(GameObject Attack,float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(Attack);
    }

}
