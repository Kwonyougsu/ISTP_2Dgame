using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloseAttack : MonoBehaviour
{
    [SerializeField] private float damege;
    [SerializeField] private float knockbackPower;
    [SerializeField] private float duration;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject attack = collision.gameObject;


        if (attack.CompareTag("Enemy"))
        {
            attack.GetComponent<EnemyHealthSystem>().ChangeHealth(-damege);
            attack.GetComponent<EnemyMovement>().ApplyKnockback(transform, knockbackPower, duration);
        }
    }
}
