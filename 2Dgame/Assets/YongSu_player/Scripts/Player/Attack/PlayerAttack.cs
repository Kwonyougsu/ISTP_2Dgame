using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject AttackPrefab;
    public Transform CloseAttackPos;
    private SpriteRenderer characterRenderer;
    private GameObject player;
    private void Awake()
    {
        characterRenderer = GetComponent<SpriteRenderer>();
        player = this.gameObject;
    }
    private void Start()
    {
        StartCoroutine(CloseAttack());  
    }
        
    IEnumerator CloseAttack()
    {
        while (true)
        {
            closeAttack();
            yield return new WaitForSeconds(1f);//공격 주기
        }
    }


    private void closeAttack()
    {
        GameObject Attack = Instantiate(AttackPrefab);

        //오른쪽 1 => false, 왼쪽 -1 =>true
        if (!characterRenderer.flipX)
        {
            Attack.transform.position = new Vector3(player.transform.position.x + 1.5f, player.transform.position.y);
        }
        else 
        {
            Attack.transform.position = new Vector3(player.transform.position.x - 1.5f, player.transform.position.y);
        }
        StartCoroutine(EndAttack(Attack, 0.05f)); //공격 유지시간
    }

    IEnumerator EndAttack(GameObject Attack,float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(Attack);
    }

}
