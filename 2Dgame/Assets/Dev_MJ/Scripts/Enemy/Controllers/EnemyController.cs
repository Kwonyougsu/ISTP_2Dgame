using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public List<GameObject> dropItems;

    protected EnemyStatHandler stats { get; private set; }

    // �÷��̾� ��ġ - �ӽ÷� ���⿡ �Ҵ� - GameManager���� ������ �޾ƿð�
    public Transform ClosestTarget { get; private set; }

    protected virtual void Awake()
    {
        // ���� ĳ��
        stats = GetComponent<EnemyStatHandler>();
    }

    protected virtual void Start()
    {
        // �÷��̾� ��ġ ĳ��
        ClosestTarget = GameManager.Instance.Player;
        GetComponent<EnemyHealthSystem>().OnDeath += DoropItem;
    }

    private void DoropItem()
    {
        Instantiate(dropItems[0], transform.position, Quaternion.identity);
        int num = UnityEngine.Random.Range(0, 10);
        switch (GameManager.Instance.itemData.itemstack[3])
        {
            case 0:
                if (num <= 1) Instantiate(dropItems[1], transform.position + new Vector3(0f, 0.7f, 0f), Quaternion.identity);
                break;

            case 1:
                if (num <= 2) Instantiate(dropItems[1], transform.position + new Vector3(0f, 0.7f, 0f), Quaternion.identity);
                break;

            case 2:
                if (num <= 3) Instantiate(dropItems[1], transform.position + new Vector3(0f, 0.7f, 0f), Quaternion.identity);
                break;

            case 3:
                if (num <= 4) Instantiate(dropItems[1], transform.position + new Vector3(0f, 0.7f, 0f), Quaternion.identity);
                break;
        }
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
}
