using UnityEngine;

public class ContactEnemyController : EnemyController
{
    [SerializeField][Range(0f, 100f)] private float followRange;
    [SerializeField] private SpriteRenderer characterRenderer;

    private bool isCollidingWithTarget;
    private int layerPlayer;
    private float curDelay;

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
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject receiver = collision.gameObject;
        if (1 << receiver.layer != layerPlayer) return;
        isCollidingWithTarget = true;
        receiver.GetComponent<PlayerHealthSystem>().PlayerChangeHealth(stats.CurrentStat.attackSO.power);
        if (!stats.CurrentStat.attackSO.isOnKnockBack) return;
        stats.CurrentStat.isChase = false;
    }

  
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isCollidingWithTarget) isCollidingWithTarget = true;
        if (curDelay > 0f) return;
        GameObject receiver = collision.gameObject;
        if (1 << receiver.layer != layerPlayer) return;
        receiver.GetComponent<PlayerHealthSystem>().PlayerChangeHealth(stats.CurrentStat.attackSO.power);
        if (!stats.CurrentStat.attackSO.isOnKnockBack) return;
        receiver.GetComponent<TopDownMovement>().ApplyKnockback(transform, stats.CurrentStat.attackSO.knockbackPower, stats.CurrentStat.attackSO.knockbackTime);
        curDelay = stats.CurrentStat.attackSO.delay;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject receiver = collision.gameObject;
        isCollidingWithTarget = false;
        stats.CurrentStat.isChase = true;
    }
}
