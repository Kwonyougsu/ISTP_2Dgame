using UnityEngine;

public class ContactEnemyController : EnemyController
{
    // 추적 범위
    [SerializeField][Range(0f, 100f)] private float followRange;
    // 플레이어 태그, 레이어 뭘로 탐지할지 정할것
    //[SerializeField] private string targetTag = "Player";
    private bool isCollidingWithTarget;
    private int layerPlayer;
    private float curDelay;


    // 캐릭터 위치에따라 이미지가 뒤집혀야한다
    //[SerializeField] private SpriteRenderer characterRenderer;//나중에 이미지 추가할것**


    protected override void Start()
    {
        base.Start();

        layerPlayer = stats.CurrentStat.target;
        curDelay = stats.CurrentStat.attackSO.delay;
    }
    private void Update()
    {
        if (isCollidingWithTarget)
        {
            curDelay -= Time.fixedDeltaTime;            
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = Vector2.zero;

        if (DistanceToTarget() < followRange)
        {
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
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;//나중에 이미지 추가할것**
    }


    // 적과 닿았을 때 처리 (근거리 공격)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"ContactEnemyController.cs - OnTriggerEnter2D()");
        GameObject receiver = collision.gameObject;

        if (1 << receiver.layer != layerPlayer) return;

        isCollidingWithTarget = true;

        //Debug.Log($"플레이어 근접 공격 성공");
        // 플레이어 체력 감소
        receiver.GetComponent<PlayerHealthSystem>().PlayerChangeHealth(stats.CurrentStat.attackSO.power);
        Debug.Log("몬스터 데미지 " + stats.CurrentStat.attackSO.power);
        if (!stats.CurrentStat.attackSO.isOnKnockBack) return;
        receiver.GetComponent<TopDownMovement>().ApplyKnockback(transform, stats.CurrentStat.attackSO.knockbackPower, stats.CurrentStat.attackSO.knockbackTime);
    }

    //private void OnTriggerStay2D(Collision2D collision)
    //{
    //    if (!isCollidingWithTarget) isCollidingWithTarget = true;
    //    if (curDelay > 0f) return;

    //    GameObject receiver = collision.gameObject;

    //    if (1 << receiver.layer != layerPlayer) return;

    //    receiver.GetComponent<PlayerHealthSystem>().PlayerChangeHealth(stats.CurrentStat.attackSO.power);
    //    if (!stats.CurrentStat.attackSO.isOnKnockBack) return;
    //    receiver.GetComponent<TopDownMovement>().ApplyKnockback(transform, stats.CurrentStat.attackSO.knockbackPower, stats.CurrentStat.attackSO.knockbackTime);
    //    curDelay = stats.CurrentStat.attackSO.delay;

    //}

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log($"ContactEnemyController.cs - OnTriggerExit2D()");

        GameObject receiver = collision.gameObject;
        isCollidingWithTarget = false;
    }
}
