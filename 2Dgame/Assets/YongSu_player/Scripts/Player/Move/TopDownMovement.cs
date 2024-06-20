using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private PlayerStatsHandler playerStatsHandler;
    private Vector2 movementDirection;   
    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    [SerializeField] private SpriteRenderer characterRenderer;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        playerStatsHandler = GetComponent<PlayerStatsHandler>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }
    private void Move(Vector2 dire)
    {

        //¿À¸¥ÂÊ 1 => false, ¿ÞÂÊ -1 =>true
        movementDirection = dire;
        if(dire.x > 0)
        {
            characterRenderer.flipX = false;
        }
        if(dire.x < 0)
        {
            characterRenderer.flipX = true;
        }
        
    }
    private void FixedUpdate()
    {
        AppiyMovemant(movementDirection);

        // ³Ë¹é È¿°ú
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }
    private void AppiyMovemant(Vector2 dire)
    {
        dire = dire * playerStatsHandler.CurrentStat.speed;


        if (knockbackDuration > 0.0f)
        {
            dire += knockback;
        }

        movementRigidbody.velocity = dire;

    }
    
    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;

        knockback = -(other.position - transform.position).normalized * power;
    }


}

