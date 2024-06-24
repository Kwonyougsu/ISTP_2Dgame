using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;

public class PlayerAttack : MonoBehaviour
{
    public GameObject[] AttackPrefab;
    public GameObject[] RotationAttackPrefab;
    private SpriteRenderer characterRenderer;
    private GameObject player;

    public float RangedAttackspeed = 100f;
    public float detectionRange = 50f;
    public Sprite[] characer;
    private int playerid;
    private GameObject closeAttackInstance;

    int objSize;
    float circleR;
    float deg;
    float objSpeed;

    private void Awake()
    {
        characterRenderer = GetComponent<SpriteRenderer>();
        player = this.gameObject;
    }
    private void Start()
    {
        objSize = 1;
        playerid = GameManager.Instance.PlayerId;
        if (playerid == 0)
        {
            characterRenderer.sprite = characer[playerid];
        }
        else if (playerid == 1)
        {
            characterRenderer.sprite = characer[playerid];
        }
        else if (playerid == 2)
        {
            characterRenderer.sprite = characer[playerid];
        }
        StartCoroutine(Attack(GameManager.Instance.PlayerId));
        //StartCoroutine(Attack());
    }

    IEnumerator Attack(int id)
    {
        
        while (true)
        {
            if (id == 0)
            {
                closeAttack();
                yield return new WaitForSeconds(0.5f);
            }
            else if (id == 1) //원거리는 탐지 먼저 해야함
            {
                Detected();
                yield return new WaitForSeconds(0.5f);
            }
            else if(id == 2)
            {
                RotationAttack();
            }
            yield return new WaitForSeconds(0.5f);//공격 주기 / 아이템으로 값 줄이면 주기 단축가능
        }
    }

    #region 근거리 공격
    private void closeAttack()
    {
        if (closeAttackInstance == null)
        {
            closeAttackInstance = Instantiate(AttackPrefab[0]);
            closeAttackInstance.SetActive(false); 
        }

        closeAttackInstance.SetActive(true);
        //오른쪽 1 => false, 왼쪽 -1 =>true
        if (!characterRenderer.flipX)
        {
            closeAttackInstance.transform.position = new Vector3(player.transform.position.x + 1.5f, player.transform.position.y);
            closeAttackInstance.GetComponent<SpriteRenderer>().flipY = false;
        }
        else
        {
            closeAttackInstance.transform.position = new Vector3(player.transform.position.x - 1.5f, player.transform.position.y);
            closeAttackInstance.GetComponent<SpriteRenderer>().flipY = true;
        }
        StartCoroutine(EndAttack(closeAttackInstance, 0.1f)); //공격 유지시간
    }

    IEnumerator EndAttack(GameObject Attack,float delay)
    {
        yield return new WaitForSeconds(delay);
        Attack.SetActive(false);
    }
    #endregion

    #region 원거리 공격

    private void Detected() // 원거리 적 감지
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
    private void RangedAttack(Transform target) // 원거리 공격 
    {
        GameObject Attack = Instantiate(AttackPrefab[1]);

        Vector3 direction = (target.position - player.transform.position).normalized;
        Attack.GetComponent<Rigidbody2D>().velocity = direction * RangedAttackspeed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Attack.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


        //오른쪽 1 => false, 왼쪽 -1 =>true
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

    #region 회전 공격
    public void RotationAttack()
    {
        deg += Time.deltaTime * objSpeed;
        if (deg < 360)
        {
            for (int i = 0; i < objSize; i++)
            {
                var rad = Mathf.Deg2Rad * (deg + (i * (360 / objSize)));
                var x = circleR * Mathf.Sin(rad);
                var y = circleR * Mathf.Cos(rad);
                RotationAttackPrefab[i].transform.position = transform.position + new Vector3(x, y);
                RotationAttackPrefab[i].transform.rotation = Quaternion.Euler(0, 0, (deg + (i * (360 / objSize))) * -1);
            }

        }
        else
        {
            deg = 0;
        }
    }
    #endregion
}

