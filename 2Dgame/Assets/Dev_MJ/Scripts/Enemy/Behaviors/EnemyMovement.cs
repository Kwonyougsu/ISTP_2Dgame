using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyController _controller;
    private Rigidbody2D _movementRigidbody;
    private EnemyStatHandler stats;
    private Vector2 _movementDirection = Vector2.zero;
    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    private void Awake()
    {       
        _controller = GetComponent<EnemyController>();
        _movementRigidbody = GetComponent<Rigidbody2D>();        
        stats = GetComponent<EnemyStatHandler>();
    }

    private void Start()
    {        
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        if (!stats.CurrentStat.isChase) return;

        ApplyMovement(_movementDirection);
      
        if (knockbackDuration > 0.0f)
        {           
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    private void Move(Vector2 direction)
    {        
        if (stats.CurrentStat.isChase) _movementDirection = direction;
        else _movementDirection = Vector2.zero;
    }

    private void ApplyMovement(Vector2 direction)
    {       
        direction = direction * stats.CurrentStat.speed;

        if (knockbackDuration > 0.0f)
        {            
            direction += knockback;
        }        
        
        _movementRigidbody.velocity = direction;
    }

    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;

        knockback = -(other.position - transform.position).normalized * power;
    }
    
}
