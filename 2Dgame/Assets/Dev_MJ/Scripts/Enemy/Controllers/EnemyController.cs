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


    // 플레이어 위치 - 임시로 여기에 할당 - GameManager에서 데이터 받아올것
    public Transform closerTarget;
    protected Transform ClosestTarget { get; private set; }

    //private SpriteRenderer spriteRenderer;

    protected virtual void Awake()
    {
        // 스텟 캐싱
        stats = GetComponent<EnemyStatHandler>();
        closerTarget = GameManager.Instance.player;
        //spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected virtual void Start()
    {
        // 플레이어 위치 캐싱
        //ClosestTarget = closerTarget;//임시
        ClosestTarget = GameManager.Instance.Player;
        GetComponent<EnemyHealthSystem>().OnDeath += DoropItem;
    }

    private void DoropItem()
    {
        Instantiate(dropItems[0], transform.position, Quaternion.identity);
        int num = UnityEngine.Random.Range(0, 4);
        if (num == 0) Instantiate(dropItems[1], transform.position + new Vector3(0f, 0.7f, 0f), Quaternion.identity);        
        
    }

    // 타겟 까지와의 거리
    protected float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, ClosestTarget.position);
    }

    // 타겟의 방향 (타겟 위치 - 본인 위치)
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
