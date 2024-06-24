using System.Collections;
using UnityEngine;

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
    private GameObject RotationAttackInstance;
    public GameObject[] mutipleRotationAttackInstance;
 
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
        circleR = 5f;
        objSpeed = 5f;
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
    private void Update()
    {
        if (playerid == 2) // ��� ���ư����ϹǷ�, Update
        {
            RotationAttack(GameManager.Instance.Lv+1);
        }
    }

    IEnumerator Attack(int id)
    {

        while (true)
        {
            if (id == 0)
            {
                closeAttack();
                yield return new WaitForSeconds(0.01f);
            }
            else if (id == 1) //���Ÿ��� Ž�� ���� �ؾ���
            {
                Detected();
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(1f - (GameManager.Instance.upgradeStatData.statLv[2] * 0.05f));
        }
    }

    #region �ٰŸ� ����
    private void closeAttack()
    {
        if (closeAttackInstance == null)
        {
            closeAttackInstance = Instantiate(AttackPrefab[0]);
            closeAttackInstance.SetActive(false);
        }

        closeAttackInstance.SetActive(true);
        //������ 1 => false, ���� -1 =>true
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
        StartCoroutine(EndAttack(closeAttackInstance, 0.1f)); //���� �����ð�
    }

    IEnumerator EndAttack(GameObject Attack, float delay)
    {
        yield return new WaitForSeconds(delay);
        Attack.SetActive(false);
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
        float time = 2; // �ı��ð�
     
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

        Destroy(Attack,time);
    }
    #endregion

    #region ȸ�� ����
    public void RotationAttack(int objsizeLv)
    {
        deg = deg % 360;
        if(objsizeLv >= 3) objsizeLv = 3;

        if (objsizeLv > 0 && objsizeLv < 2)
        {
            if (RotationAttackInstance == null)
            {
                RotationAttackInstance = Instantiate(RotationAttackPrefab[0]);
            }

            deg += Time.deltaTime * (objSpeed + GameManager.Instance.upgradeStatData.statLv[2] * 2f) * 10;

            var rad = Mathf.Deg2Rad * (deg);
            var x = circleR * Mathf.Sin(rad);
            var y = circleR * Mathf.Cos(rad);
            RotationAttackInstance.transform.position = transform.position + new Vector3(x, y);
            RotationAttackInstance.transform.rotation = Quaternion.Euler(0, 0, deg * -1); // ����� �ٶ󺸰� ���� ����
            Debug.Log(RotationAttackInstance.transform.position);
        }
        else if (objsizeLv >= 2)
        {
            if (RotationAttackInstance != null)
            {
                Destroy(RotationAttackInstance);
            }

            if (mutipleRotationAttackInstance != null && mutipleRotationAttackInstance.Length == objsizeLv-1)
            {
                for (int i = 0; i < mutipleRotationAttackInstance.Length; i++)
                Destroy(mutipleRotationAttackInstance[i]);
            }

            if (mutipleRotationAttackInstance == null || mutipleRotationAttackInstance.Length != objsizeLv)
            {
                mutipleRotationAttackInstance = new GameObject[objsizeLv];
            }

            for (int i = 0; i < objsizeLv; i++)
            {
                if (mutipleRotationAttackInstance[i] == null)
                {
                    mutipleRotationAttackInstance[i] = Instantiate(RotationAttackPrefab[0]);
                }
            }

            deg += Time.deltaTime * (objSpeed + GameManager.Instance.upgradeStatData.statLv[2] * 2f) * 10;

            for (int i = 0; i < objsizeLv; i++)
            {
                var rad = Mathf.Deg2Rad * (deg + (i * (360 / objsizeLv)));
                var x = circleR * Mathf.Sin(rad);
                var y = circleR * Mathf.Cos(rad);
                mutipleRotationAttackInstance[i].transform.position = transform.position + new Vector3(x, y);
                mutipleRotationAttackInstance[i].transform.rotation = Quaternion.Euler(0, 0, (deg + (i * (360 / objsizeLv))) * -1);
                Debug.Log(mutipleRotationAttackInstance[i].transform.position);
            }
        }
    }
    #endregion
}

