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
        // ���콺�� ��ġ�� ������ OnLookEvent�� ����ϴ� ��
        // ���콺�� ��ġ�� �޾Ƽ� ���� ������ �� Ȱ���� ����.
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
