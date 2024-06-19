using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<EnemyAttackSO> OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;   
    protected EnemyStatHandler stats { get; private set; }


    // �÷��̾� ��ġ - �ӽ÷� ���⿡ �Ҵ� - GameManager���� ������ �޾ƿð�
    public Transform closerTarget;//�ӽ�
    protected Transform ClosestTarget { get; private set; }

    protected virtual void Awake()
    {
        // ���� ĳ��
        stats = GetComponent<EnemyStatHandler>();
    }

    protected virtual void Start()
    {
        // �÷��̾� ��ġ ĳ��
        ClosestTarget = closerTarget;//�ӽ�
        //ClosestTarget = GameManager.Instance.Player;
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
