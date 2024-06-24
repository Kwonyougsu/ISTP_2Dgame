using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<EnemyAttackSO> OnAttackEvent;
    public List<GameObject> dropItems;

    private float _timeSinceLastAttack = float.MaxValue;   
    protected EnemyStatHandler stats { get; private set; }  


    // �÷��̾� ��ġ - �ӽ÷� ���⿡ �Ҵ� - GameManager���� ������ �޾ƿð�
    public Transform closerTarget;
    protected Transform ClosestTarget { get; private set; }

    //private SpriteRenderer spriteRenderer;

    protected virtual void Awake()
    {
        // ���� ĳ��
        stats = GetComponent<EnemyStatHandler>();
        closerTarget = GameManager.Instance.player;
        //spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected virtual void Start()
    {
        // �÷��̾� ��ġ ĳ��
        //ClosestTarget = closerTarget;//�ӽ�
        ClosestTarget = GameManager.Instance.Player;
        GetComponent<EnemyHealthSystem>().OnDeath += DoropItem;
    }

    private void DoropItem()
    {
        Instantiate(dropItems[0], transform.position, Quaternion.identity);
        int num = UnityEngine.Random.Range(0, 4);
        if (num == 0) Instantiate(dropItems[1], transform.position + new Vector3(0f, 0.7f, 0f), Quaternion.identity);        
        
    }

    // Ÿ�� �������� �Ÿ�
    protected float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, ClosestTarget.position);
    }

    // Ÿ���� ���� (Ÿ�� ��ġ - ���� ��ġ)
    protected Vector2 DirectionToTarget()
    {        
        return (ClosestTarget.position - transform.position).normalized;
    }

    public void CallMoveEvent(Vector2 direction)
    {
        //if (ClosestTarget.position.x < transform.position.x)
        //{
        //    spriteRenderer.flipX = true;
        //}
        //else
        //{
        //    spriteRenderer.flipX = false;
        //}
        OnMoveEvent?.Invoke(direction);
    }
    public void CallLookEvent(Vector2 direction)
    {       
        OnLookEvent?.Invoke(direction);
    }
    private void CallAttackEvent(EnemyAttackSO attackSO)
    {        
        OnAttackEvent?.Invoke(attackSO);
    }

}
