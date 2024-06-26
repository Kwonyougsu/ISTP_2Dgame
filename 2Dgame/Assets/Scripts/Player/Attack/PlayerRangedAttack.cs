using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour
{
    [SerializeField] private float damege;
    [SerializeField] private float knockbackPower;
    [SerializeField] private float duration;
    public ItemData itemdata;
    public AudioClip clip;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D() - �浹");
        GameObject attack = collision.gameObject;

        if (attack.CompareTag("Enemy"))
        {
            SoundManager.PlayClip(clip);
            attack.GetComponent<EnemyHealthSystem>().ChangeHealth(-(damege + (5 * itemdata.itemstack[0]) + (5 * GameManager.Instance.upgradeStatData.statLv[0])));
            attack.GetComponent<EnemyMovement>().ApplyKnockback(transform, knockbackPower, duration);
            Destroy(this.gameObject);
        }
    }
}
