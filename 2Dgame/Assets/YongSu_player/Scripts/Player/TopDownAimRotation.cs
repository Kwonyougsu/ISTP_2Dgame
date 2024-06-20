using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    private TopDownController Controller;

    private void Awake()
    {
        Controller = GetComponent<TopDownController>();
    }
    private void Start()
    {
        // 마우스의 위치가 들어오는 OnLookEvent에 등록하는 것
        // 마우스의 위치를 받아서 팔을 돌리는 데 활용할 것임.
        Controller.OnLookEvent += OnAim;
    }
    private void OnAim(Vector2 dire)
    {
        RotateArm(dire);
    }

    private void RotateArm(Vector2 dire)
    {
        float rotZ = Mathf.Atan2(dire.y, dire.x) * Mathf.Rad2Deg;
    }
}
