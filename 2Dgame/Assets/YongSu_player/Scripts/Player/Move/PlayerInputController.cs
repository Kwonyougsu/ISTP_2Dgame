using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera camera;
    public event Action<Vector2> OnMoveEvent;
    protected override void Awake()
    {
        //mainCamera태그의 카메라를 가져옴
        camera = Camera.main;
    }
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        OnMoveEvent?.Invoke(moveInput);
        CallMoveEvent(moveInput);
    }
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;
        CallLookEvent(newAim);
    }
}

