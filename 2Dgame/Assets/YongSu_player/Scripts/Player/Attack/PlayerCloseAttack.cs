using UnityEngine;

public class PlayerCloseAttack : MonoBehaviour
{
    [SerializeField] private float damege;
    [SerializeField] private float knockbackPower;
    [SerializeField] private float duration;
    public ItemData itemdata;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D() - Ãæµ¹");
        GameObject attack = collision.gameObject;

        if (attack.CompareTag("Enemy"))
        {
            attack.GetComponent<EnemyHealthSystem>().ChangeHealth(-(damege + (5 * itemdata.itemstack[0])));
            attack.GetComponent<EnemyMovement>().ApplyKnockback(transform, knockbackPower, duration);
        }
    }
}
