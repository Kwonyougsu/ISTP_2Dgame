using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject[] AttackPrefab;
    private SpriteRenderer characterRenderer;
    private GameObject player;

    public float RangedAttackspeed = 100f;
    public float detectionRange = 50f;
    public Sprite[] characer;
    private int playerid;

    private void Awake()
    {
        characterRenderer = GetComponent<SpriteRenderer>();
        player = this.gameObject;
    }
    private void Start()
    {
        playerid = PlayerGameManager.Instance.PlayerId;
        if (playerid == 0)
        {
            characterRenderer.sprite = characer[playerid];
        }
        if (playerid == 1)
        {
            characterRenderer.sprite = characer[playerid];
        }
        StartCoroutine(Attack(PlayerGameManager.Instance.PlayerId));  
    }

    IEnumerator Attack(int id)
    {
        
        while (true)
        {
            if(id == 0)
            {
                closeAttack();
                yield return new WaitForSeconds(0.5f);
            }
            else if (id == 1) //���Ÿ��� Ž�� ���� �ؾ���
            {
                Detected();
                yield return new WaitForSeconds(0.5f);
            }
            
            yield return new WaitForSeconds(0.5f);//���� �ֱ� / ���������� �� ���̸� �ֱ� ���డ��
        }
    }

    #region �ٰŸ� ����
    private void closeAttack()
    {
        GameObject Attack = Instantiate(AttackPrefab[0]);

        //������ 1 => false, ���� -1 =>true
        if (!characterRenderer.flipX)
        {
            Attack.transform.position = new Vector3(player.transform.position.x + 1.5f, player.transform.position.y);
        }
        else 
        {
            Attack.transform.position = new Vector3(player.transform.position.x - 1.5f, player.transform.position.y);
        }
        StartCoroutine(EndAttack(Attack, 0.05f)); //���� �����ð�
    }

    IEnumerator EndAttack(GameObject Attack,float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(Attack);
    }
    #endregion

    #region ���Ÿ� ����

    private void Detected() // ���Ÿ� �� ����
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(player.transform.position, detectionRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                RangedAttack(hitCollider.transform);
            }
        }
    }
    private void RangedAttack(Transform target) // ���Ÿ� ���� 
    {
        GameObject Attack = Instantiate(AttackPrefab[1]);

        Vector3 direction = (target.position - player.transform.position).normalized;
        Attack.GetComponent<Rigidbody2D>().velocity = direction * RangedAttackspeed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Attack.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


        //������ 1 => false, ���� -1 =>true
        if (!characterRenderer.flipX)
        {
            Attack.transform.position = new Vector3(player.transform.position.x, player.transform.position.y);
        }
        else
        {
            Attack.transform.position = new Vector3(player.transform.position.x, player.transform.position.y);
        }

    }
    #endregion

}

