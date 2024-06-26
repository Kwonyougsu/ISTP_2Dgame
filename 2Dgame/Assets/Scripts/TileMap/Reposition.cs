using UnityEngine;

public class Reposition : MonoBehaviour
{
    private Collider2D collider2D;

    private void Awake()
    {
        collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.Instance.playerDirection.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.Instance.playerDirection.movementDirection;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 70);
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 70);
                }
                break;

            case "Enemy":
                if (collider2D.enabled)
                {
                    transform.Translate(playerDir * 35 + new Vector3(Random.Range(-3f, -3f), Random.Range(-3f, -3f), 0));
                }
                break;
        }
    }
}
