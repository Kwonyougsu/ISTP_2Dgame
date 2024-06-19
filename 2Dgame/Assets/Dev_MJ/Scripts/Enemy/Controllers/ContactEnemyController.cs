using UnityEngine;

public class ContactEnemyController : EnemyController
{
    // 추적 범위
    [SerializeField][Range(0f, 100f)] private float followRange;
    // 플레이어 태그, 레이어 뭘로 탐지할지 정할것
    //[SerializeField] private string targetTag = "Player";
    private bool isCollidingWithTarget;
    private int layerPlayer;

    // 캐릭터 위치에따라 이미지가 뒤집혀야한다
    //[SerializeField] private SpriteRenderer characterRenderer;//나중에 이미지 추가할것**

  

    protected override void Start()
    {
        base.Start();

        layerPlayer = stats.CurrentStat.target;       
    }

    private void FixedUpdate()
    {
             
        Vector2 direction = Vector2.zero;

        // 타겟 추격 가능
        if (DistanceToTarget() < followRange)
        {
            // 타겟 방향
            direction = DirectionToTarget();
        }
        
        CallMoveEvent(direction);
        Rotate(direction);
    }

    private void OnDamage()
    {        
        followRange = 100f;
    }

    private void Rotate(Vector2 direction)
    {        
        // Atan2는 가로와 세로의 비율을 바탕으로 -파이~파이(-180도~180도에 대응, * Rad2Deg가 그 기능)하는 값을 나타내주는 함수였다는 것 기억하시죠?
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;//나중에 이미지 추가할것**
    }

    // 적과 닿았을 때 처리 (근거리 공격)
    private void OnCollisionEnter2D(Collision2D collision)
    {     
        GameObject receiver = collision.gameObject;      

        if (1 <<receiver.layer == layerPlayer)
        {
            Debug.Log($"플레이어 근접 공격 성공");
            // 플레이어 체력 감소

        }


        // 플레이어가 아닐경우 무시


        // 플레이어일 경우 데미지
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject receiver = collision.gameObject;
       
    }
}
