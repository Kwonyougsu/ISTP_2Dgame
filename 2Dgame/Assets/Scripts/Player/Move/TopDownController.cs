using System;
using UnityEngine;


public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;

    protected PlayerStatsHandler stats { get; private set; }

    protected virtual void Awake()
    {
        stats = GetComponent<PlayerStatsHandler>();
    }

    public void CallMoveEvent(Vector2 direction)
    {
        //?.없으면 말고 있으면 실행
        OnMoveEvent?.Invoke(direction);
    }
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}
