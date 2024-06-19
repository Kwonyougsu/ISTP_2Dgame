using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private Vector2 movementDirection;

    [SerializeField] private int speed = 5;
    [SerializeField] private SpriteRenderer characterRenderer;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
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
    }
    private void AppiyMovemant(Vector2 dire)
    {
        dire = dire * speed;
        movementRigidbody.velocity = dire;
    }


}

